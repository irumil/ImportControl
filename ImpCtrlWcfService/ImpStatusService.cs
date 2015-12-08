using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;
using ImpStatusLibrary;

namespace ImpCtrlWcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class ImpStatusService : IImpStatusService
    {
        private IImpStatusServiceCallback _callBackFunc;
        private readonly ImportControlSetting _impCtrlSettings;
        private readonly ImportController _impController;

        public ImpStatusService()
        {
            _impCtrlSettings = ImportControlSetting.GetSettings();
            _impController = new ImportController(_impCtrlSettings);
            _impController.StatusChanged += Log;
            ShowSettingImpCtrl();
        }

        private void ShowSettingImpCtrl()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"------------------------------------");
            Console.WriteLine(@"Для изменения настроек используйте ImpCtrlSetting.exe, ");
            Console.WriteLine(@"после изменний перезапустите службу");
            Console.WriteLine(@"Путь к импорту: {0}", _impCtrlSettings.ImportPath);
            Console.WriteLine(@"Слежение за Импортом: " + DrawBoolean(_impCtrlSettings.WorkIt));
            Console.WriteLine(@"Интервал слежения за импортом: {0} сек.", _impCtrlSettings.Interval);
            Console.WriteLine(@"Слежение за логом Импорта: " + DrawBoolean(_impCtrlSettings.WorkLogImport));
            Console.WriteLine(@"Интервал слежения за логом Импорта: {0} сек.", _impCtrlSettings.IntervalLogImport);
            Console.WriteLine(@"Закрывать повисший Импорт: " + DrawBoolean(_impCtrlSettings.KillNoRespondProc));
            Console.WriteLine(@"Счетчик для запроса повисшего Импорта: {0}  попыток", _impCtrlSettings.CountForRespondToProc);
            Console.WriteLine(@"Закрывать лишние копии Импорта: " + DrawBoolean(_impCtrlSettings.CloseCopyImport));
            Console.WriteLine(@"------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string DrawBoolean(bool value)
        {
            return value ? "[v]" : "[ ]";
        }

        public List<string> GetFullLog()
        {
            return _impController.GetFullLogWork;
        }

        public string GetImportProtocol()
        {
            return _impController.GetImportProtocol();
        }

        public void RegistrCallbackClientFunc()
        {
            _callBackFunc = OperationContext.Current.GetCallbackChannel<IImpStatusServiceCallback>();
        }
       
        private void Log(string message)
        {
            try
            {
                var sendMessage =  string.Format("[{0}]: {1}", DateTime.Now, message);
                
                Console.SetCursorPosition(0, 18);
                Console.Write(@"                                                                            ");
                Console.SetCursorPosition(0, 18);
                Console.Write(sendMessage);
                
                if (_callBackFunc != null) _callBackFunc.OnStatusComplete(sendMessage);
            }
            catch (CommunicationException comEx)
            {
                _callBackFunc = null;
               //logToFile Console.WriteLine("Ошибка подключения " + comEx.Message);
            }
            catch (Exception ex)
            {
                _callBackFunc = null;
                //logToFile Console.WriteLine("Неизвестная ошибка "+ex.Message);
            }
        }

        public string GetLastSatus()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine(@"[{0}]: {1}", DateTime.Now, @"Запрошен последний статус");
            return _impController.GetLastStatus();
        }

        public Image GetImageStatus()
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            return printscreen;
        }

        public byte[] GetScreenshot()
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage((Image) printscreen);
            Rectangle bounds = new Rectangle();
 

            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save("ee.jpg");

            byte[] result = PackScreenCaptureData(printscreen, bounds);

            return result;
        }

        public static Guid Id = Guid.NewGuid();

        public static byte[] PackScreenCaptureData(Image image, Rectangle bounds)
        {
            // Pack the image data into a byte stream to
            //	be transferred over the wire.
            //

            // Get the bytes of the Id
            //
            byte[] idData = Id.ToByteArray();

            // Get the bytes of the image data.
            //	Notice: We are using JPEG compression.
            //
            byte[] imgData;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgData = ms.ToArray();
            }

            // Get the bytes that describe the bounding
            //	rectangle.
            //
            byte[] topData = BitConverter.GetBytes(bounds.Top);
            byte[] botData = BitConverter.GetBytes(bounds.Bottom);
            byte[] leftData = BitConverter.GetBytes(bounds.Left);
            byte[] rightData = BitConverter.GetBytes(bounds.Right);

            // Create the final byte stream.
            // Notice: We are streaming back both the bounding
            //	rectangle and the image data.
            //
            int sizeOfInt = topData.Length;
            byte[] result = new byte[imgData.Length + 4 * sizeOfInt + idData.Length];
            Array.Copy(topData, 0, result, 0, topData.Length);
            Array.Copy(botData, 0, result, sizeOfInt, botData.Length);
            Array.Copy(leftData, 0, result, 2 * sizeOfInt, leftData.Length);
            Array.Copy(rightData, 0, result, 3 * sizeOfInt, rightData.Length);
            Array.Copy(imgData, 0, result, 4 * sizeOfInt, imgData.Length);
            Array.Copy(idData, 0, result, 4 * sizeOfInt + imgData.Length, idData.Length);

            return result;
        }
    }
}
