using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ImpStatusLibrary
{
    public class ImportController
    {
        private readonly Timer _timerCheckRunnigProgramm;
        private readonly Timer _timerTrackingWorkImport;
        private readonly ImportControlSetting _impSettings;
        
        private int _factCountNotRespond;
        private int _proirLengthMemoText;
        private int _countNotWork;

        #region PublicEvents
        public event Action<string> StatusChanged;
        public event Action<Image> ImageStatusChanged;
        #endregion PublicEvents

        #region  ImportControlManagerFunction
        public string ImportPath { get; set; }
        public bool KillNoRespondProc { get; set; }
        public int CountForRespondToProc { get; set; }
        public bool CloseCopyImport { get; set; }
        private string ImportName { get { return Path.GetFileNameWithoutExtension(ImportPath); } }
        public double Interval {
            get { return _timerCheckRunnigProgramm.Interval/1000; }
            set { _timerCheckRunnigProgramm.Interval = value*1000; }
        }
        public double IntervalLogImport
        {
            get { return _timerTrackingWorkImport.Interval / 1000; }
            set { _timerTrackingWorkImport.Interval = value * 1000; }
        }
        public void EnableWork(bool enable)
        {
            _impSettings.WorkIt = enable;
            _timerCheckRunnigProgramm.Enabled = enable;
        }
        public void EnableTarckingLogImport(bool enable)
        {
            _impSettings.WorkLogImport = enable;
            _timerTrackingWorkImport.Enabled = enable;
        }
        #endregion ImportControlManagerFunction

        #region ImportCtrlConstrucorDestructor
        public ImportController(ImportControlSetting settings)
        {
            _impSettings = settings;
            ImportPath = _impSettings.ImportPath;

            _timerCheckRunnigProgramm = new Timer()
            {
                Interval = _impSettings.Interval*1000,
                Enabled = _impSettings.WorkIt,
                AutoReset = true
            };
            _timerCheckRunnigProgramm.Elapsed += OnTimerCheckStatus;

            _timerTrackingWorkImport = new Timer()
            {
                Interval = _impSettings.IntervalLogImport*1000,
                Enabled = _impSettings.WorkLogImport,
                AutoReset = true
            };
            _timerTrackingWorkImport.Elapsed += OnTimerWorkStatus;

            CountForRespondToProc = _impSettings.CountForRespondToProc;
            KillNoRespondProc = _impSettings.KillNoRespondProc;
            CloseCopyImport = _impSettings.CloseCopyImport;
        }

        ~ImportController()
        {
            _impSettings.KillNoRespondProc = KillNoRespondProc;
            _impSettings.CloseCopyImport = CloseCopyImport;
            _impSettings.CountForRespondToProc = CountForRespondToProc;
            _impSettings.ImportPath = ImportPath;
            _impSettings.Interval = Interval;
            _impSettings.IntervalLogImport = IntervalLogImport;
            _impSettings.Save();
        }
        #endregion ImportCtrlConstrucorDestructor

        #region FunctionCheckWorkStateLogImport
        private void OnTimerWorkStatus(object sender, ElapsedEventArgs e)
        {
            // выходим если Импорт не запущен
            var lengthMemoText = GetLengthTextByHandle(GetHandleTMemo());
            if (lengthMemoText==0) return;

            if ((lengthMemoText == _proirLengthMemoText) )
            {
                var intervalSec = ((_countNotWork+1) * _timerTrackingWorkImport.Interval)/1000;
                var timeSpanFromInterval = TimeSpan.FromSeconds(intervalSec);
                var timeNotLog = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpanFromInterval.Hours, timeSpanFromInterval.Minutes, timeSpanFromInterval.Seconds);
                
                _countNotWork++;
                
                SetStatus(string.Format("Импорт не записывает работу в протокол: {0}", timeNotLog));
            }
            else
            {
                _countNotWork = 0;
            }
            _proirLengthMemoText = lengthMemoText;
        }

        private IntPtr GetHandleTMemo()
        {
            var importForm = DllImportMethods.FindWindow("TFormImport", "ЗАПИСЬ В БАЗУ ASUSS");
            if (importForm.ToString() == "0") importForm = DllImportMethods.FindWindow("TFormImport", "ЗАПИСЬ В БАЗУ ");
            var memoHandle = DllImportMethods.FindWindowEx(importForm, new IntPtr(0), "TMemo", null);
            if (memoHandle.ToString() == "0") SetStatus("Не найдено окно Импорта");
            return memoHandle;
        }

        private int GetLengthTextByHandle(IntPtr hWnd)
        {
            const int WM_GETTEXTLENGTH = 0x000E;
            IntPtr hndl = Marshal.AllocHGlobal(200);
            int numText = (int)DllImportMethods.SendMessage(hWnd, WM_GETTEXTLENGTH, (IntPtr)2000, hndl);
            return (numText);
        }
        #endregion FunctionCheckWorkStateLogImport

        /// <summary>
        /// Ищем  текст с протоколом импорта
        /// </summary>
        /// <returns>Возвращаем строку с протоколом Импорта</returns>
        public string GetImportProtocol()
        {
            return GetImportMemoText(GetHandleTMemo());
        }
        
        private string GetImportMemoText(IntPtr hControlBox)
        {
            uint WM_GETTEXT = 0x000D;
            int len = GetLengthTextByHandle(hControlBox); 
            if (len <= 0) return null;  
            StringBuilder sb = new StringBuilder(len + 1);
            DllImportMethods.SendMessageForGetText(hControlBox, WM_GETTEXT, len + 1, sb);
            return sb.ToString();
        }

        private void OnTimerCheckStatus(object sender, ElapsedEventArgs e)
        {
            CheckRuningStatus();
            CheckAndCloseErrorWindowImport();
            CheckRespondProc();
        }

        /// <summary>
        /// Проверяем статус Импорта (запущен, не запущен, запущен несколько раз)
        /// </summary>
        /// <returns>Возвращаем строку со статусом  </returns>
        public string CheckRuningStatus()
        {
            if (ImportName == string.Empty) return "Не указан путь к Импорту";

            string statusNow = "Проверяем статус Импорта...";

            switch (GetImportProcess().Count())
            {
                case 0:
                {
                    statusNow = "Импорт Не запущен!";

                    SetStatus(statusNow);
                    SetImageStatus(Properties.Resources.importNotRuning);
                    
                    RunImport();
                    break;
                }
                case 1:
                {
                    statusNow = "Импорт запущен!";

                    SetImageStatus(Properties.Resources.importRuning);
                    break;
                }
                default:
                {
                    if (CloseCopyImport)
                    {
                        statusNow = "Импорт запущен несколько раз!";

                        SetStatus(statusNow);
                        SetImageStatus(Properties.Resources.importRuningCopy);

                        if (CloseImport())
                        {
                            statusNow = "Импорт благополучно закрыли";
                            SetStatus(statusNow);
                        }
                        else
                        {
                            statusNow = "Импорт не смогли закрыть, закрываем принудительно";
                            SetStatus(statusNow);
                            KillImportWindow();
                        }
                    }
                    break;
              }   
            }
            return statusNow;
        }

        /// <summary>
        /// Закрываем всякого рода окна и не нужные сообщения Импорта
        /// </summary>
        public void CheckAndCloseErrorWindowImport()
        {
            // ловим заголовок сообщения об ошибке Импорта
            IntPtr messageErrorForm = DllImportMethods.FindWindow("TMessageForm", "Import");
            if (messageErrorForm != IntPtr.Zero)
            {
                SetStatus("Закрыли сообщение " + messageErrorForm);
                CloseWindow(messageErrorForm);
            }

            //ловим заголовок диалога об ошибке
            IntPtr dialogErrorForm = DllImportMethods.FindWindow("#32770", "Import");
            if (dialogErrorForm != IntPtr.Zero)
            {
                SetStatus("Закрыли диалог об ошибке " + dialogErrorForm);
                CloseWindow(dialogErrorForm);
            }
        }

        /// <summary>
        /// Закрытие окна по Handle
        /// </summary>
        /// <param name="handle">Handle закрываемого окна</param>
        private void CloseWindow(IntPtr handle)
        {
            const uint WM_CLOSE = 0x10;
            DllImportMethods.SendMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Получить все процессы Импорта
        /// </summary>
        /// <returns>Возвращает IEnumerable<Process> для Импорта</returns>
        private IEnumerable<Process> GetImportProcess()
        {
            var procesQuery = from runProc in Process.GetProcesses()
                              where string.Equals(runProc.ProcessName, ImportName, StringComparison.CurrentCultureIgnoreCase)
                              select runProc;
            return procesQuery;
        }

        /// <summary>
        /// Закрываем принудительно через Kill все процессы Импорта
        /// </summary>
        public void KillImportWindow()
        {
            foreach (var p in GetImportProcess())
            {
                p.Kill();
                SetStatus("Импорт принудительно закрыт!");
                SetImageStatus(Properties.Resources.importNotRuning);
            }
        }

        /// <summary>
        /// Закрываем через Close все процессы импорта
        /// </summary>
        /// <returns>Возвращаем результат оперции</returns>
        public bool CloseImport()
        {
           var result = false;

           foreach (var pR in GetImportProcess())
            {
                if (pR.CloseMainWindow())
                {
                    result = true;

                    SetStatus("Импорт Закрыт!");
                    SetImageStatus(Properties.Resources.importNotRuning);
                }
            }
            return result;
        }

        /// <summary>
        /// Запускаем Импорт
        /// </summary>
        /// <returns>Возвращаем результат оперции
        /// Если путь к импорту не указан то возвращаем False
        /// Если процесс удалось запусть то возвращем True
        /// </returns>
        public bool RunImport()
        {
            var result = false;

            if  ((ImportName  == string.Empty) | (!File.Exists(ImportPath))) 
            {
                SetStatus("Не верно указан путь к Импорту");
                return false;
            }
            
            try
            {
                var importProcess = new Process
                {StartInfo =
                    {
                        FileName = ImportPath,
                        WindowStyle = ProcessWindowStyle.Normal,
                        WorkingDirectory = Path.GetDirectoryName(ImportPath)
                    }};

                result = importProcess.Start();
                string msg = result ? "Импорт запущен! " : "Не удалось запустить Импорт!";

                SetStatus(msg);
                SetImageStatus(result ? Properties.Resources.importRuning : Properties.Resources.importNotRuning);
            }
            catch (Exception e)
            {
                SetStatus(string.Format("Ошибка запуска: {0}: {1} ", e.Message, ImportName));
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Проверяем повисший Импорт
        /// </summary>
        private void CheckRespondProc()
        {
            if (!KillNoRespondProc) return;
            var procesQuery = GetImportProcess().Where(p => p.Responding == false);

            if (procesQuery.Count() == 0) return;
   
            _factCountNotRespond++;
            SetStatus("Импорт не отвечает " + _factCountNotRespond + " отклика");
            SetImageStatus(Properties.Resources.importNotAnswer);

            foreach (var p in procesQuery)
            {
                if (_factCountNotRespond >= CountForRespondToProc)
                {
                    try
                    {
                        p.Kill();
                        _factCountNotRespond = 0;
                        SetStatus("Импорт повис, принудительно закрыли!!!");
                    }
                    catch (Exception ex)
                    {
                        SetStatus("Не удалось закрыть повисший Импорт " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Здесь будем хранить последние ообщения ImportControl
        /// </summary> 
        private readonly List<string> _log = new List<string>();

        /// <summary>
        /// Отдаем сообщения из Лога работы программы
        /// </summary> 
        public List<string> GetFullLogWork
        {
            get
            {
                _log.Insert(0,"-------Последние 20 строк Лога работы-------");
                return _log;
            }
        }

        public string GetLastStatus()
        {
            if (_log.Count == 0) return string.Format("[{0}]: {1}", DateTime.Now,CheckRuningStatus());
            return  _log.Last();
        }

        /// <summary>
        /// Посылаем подписчику события сообщение
        /// Тут же добавляем сообщение в лог, проверяя количество сообщений в списке логов
        /// </summary>
        /// <param name="message">Сообщение для отправки</param>
        private void SetStatus(string message)
        {
            if (StatusChanged != null) StatusChanged(message);

            if (_log.Count>19) _log.RemoveAt(0);
            _log.Add(string.Format("[{0}]: {1}", DateTime.Now, message));
        }

        /// <summary>
        /// Посылаем подписчику события картинку статуса Импорта
        /// </summary>
        /// <param name="image">Картинка статуса</param>
        private void SetImageStatus(Image image)
        {
            if (ImageStatusChanged != null) ImageStatusChanged(image);
        }
    }
}
