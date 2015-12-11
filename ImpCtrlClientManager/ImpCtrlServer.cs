using System;
using System.ComponentModel;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using System.Xml.Serialization;
using ImpCtrlClientManager.ImpService;
using System.IO;

namespace ImpCtrlClientManager
{
    public class ImpCtrlServer : INotifyPropertyChanged, IImpStatusServiceCallback
    {
        private bool _needWatch;
        private string _ipAdress;
        private string _description;
        private string _status;

        private ImpStatusServiceClient _clientWcf;

        #region Public Browsable Fields

        [DisplayName("Следить")]
        public bool NeedWatch
        {
            get { return _needWatch; }
            set
            {
                _needWatch = value;
                OnPropertyChanged("NeedWatch");
            }
        }

        [DisplayName("IP Адрес")]
        public string IpAdress
        {
            get { return _ipAdress; }
            set
            {
                _ipAdress = value;
                OnPropertyChanged("IpAdress");
            }
        }

        [DisplayName("Описание")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        [XmlIgnore]
        [DisplayName("Сообщения")]
        public string StatusInfo
        {
            get { return _status; }
        }

        #endregion Public Browsable Fields

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }

       private void InitializeClient()
        {
            try
            {
                if (_clientWcf == null || _clientWcf.State == CommunicationState.Closed || _clientWcf.State== CommunicationState.Faulted)
                {
                    _clientWcf = new ImpStatusServiceClient(new InstanceContext(this), "NetTcpBinding_IImpStatusService");
                    _clientWcf.Endpoint.Address =
                        new EndpointAddress(string.Format("net.tcp://{0}:8738/ImpCtrlSvc", _ipAdress));
                    _clientWcf.Open();
                }
            }
            catch (Exception ex)
            {
                if (_clientWcf != null)
                {
                    _clientWcf.Abort();
                }
                _status = "Не удалось создать подключение к серверу ";
            }
        }

        private void SetStatusInfo(string message)
        {
            _status = message;
            OnPropertyChanged("StatusInfo");
        }

        public async void RegisterCallbackFuncToService()
        {
            try
            {
                InitializeClient();
                await _clientWcf.RegistrCallbackClientFuncAsync();
            }
            catch (Exception ex)
            {
                SetStatusInfo("Ошибка регистрации клиента на сервере ");
            }
            GetLastStatusFromWcfAsync();
        }
        
        public async void GetLastStatusFromWcfAsync()
        {
            if (_clientWcf == null)
            {
                SetStatusInfo("Клиент не подключен к серверу");
                return;
            }

            try
            {
                string result = await _clientWcf.GetLastSatusAsync();
                SetStatusInfo(result);
            }
            catch (Exception ex)
            {
                SetStatusInfo("Ошибка получения статуса, возможно не запущена служба на сервере");
            }
        }

        public void OnStatusComplete(string message)
        {
            SetStatusInfo(message);
        }

        public void DisconnectFromWcfService()
        {
            SetStatusInfo("Отключаемся...");
            if (_clientWcf == null) return;
            
            try
            {
                if (_clientWcf.State != CommunicationState.Closed)
                {
                    _clientWcf.Close();
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("Ошибка отключения, перезапустите программу");
            }
        }

        public string[] GetFullLogFromServer()
        {
            InitializeClient();
            string[] logFromServer = new string[1];
            try
            {
                logFromServer = _clientWcf.GetFullLog();
            }
            catch (Exception ex)
            {
                 SetStatusInfo("Ошибка получения лога ");
            }
            string result = String.Format("Лог работы с сервера {0}({1})", Description, IpAdress);
            _status = result;
            logFromServer.SetValue(result, 0);
            return logFromServer;
        }

        public async void GetScreenshotImageFromWcf()
        {
            InitializeClient();
            
            try
            {
                byte[] screenShot = await _clientWcf.GetScreenshotAsync();

                Guid id;// = Guid.NewGuid();
                Rectangle bounds;// = new Rectangle();
                Image imageScreenShot;
                UnpackScreenCaptureData(screenShot, out imageScreenShot, out bounds, out id);

                imageScreenShot.Save("dd.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения скрина ");
            }

        }

        public string GetImportProtocol()
        {
            InitializeClient();
            string logFromServer  = string.Empty;
            try
            {
                logFromServer = _clientWcf.GetImportProtocol();
            }
            catch (Exception ex)
            {
                SetStatusInfo("Ошибка получения протокола");
            }
       
            string line = new string('-', 100);
            return string.Format("{4} {2} Протокол работы Импорта с сервера {0}({1}) {2} {4} {2} {3} {4}", 
                Description, IpAdress, Environment.NewLine,logFromServer, line);
        }

        public static void UnpackScreenCaptureData(byte[] data, out Image image, out Rectangle bounds, out Guid id)
        {
            // Unpack the data that is transferred over the wire.
            //

            // Create byte arrays to hold the unpacked parts.
            //
            const int numBytesInInt = sizeof(int);
            int idLength = Guid.NewGuid().ToByteArray().Length;
            int imgLength = data.Length - 4 * numBytesInInt - idLength;
            byte[] topPosData = new byte[numBytesInInt];
            byte[] botPosData = new byte[numBytesInInt];
            byte[] leftPosData = new byte[numBytesInInt];
            byte[] rightPosData = new byte[numBytesInInt];
            byte[] imgData = new byte[imgLength];
            byte[] idData = new byte[idLength];

            // Fill the byte arrays.
            //
            Array.Copy(data, 0, topPosData, 0, numBytesInInt);
            Array.Copy(data, numBytesInInt, botPosData, 0, numBytesInInt);
            Array.Copy(data, 2 * numBytesInInt, leftPosData, 0, numBytesInInt);
            Array.Copy(data, 3 * numBytesInInt, rightPosData, 0, numBytesInInt);
            Array.Copy(data, 4 * numBytesInInt, imgData, 0, imgLength);
            Array.Copy(data, 4 * numBytesInInt + imgLength, idData, 0, idLength);

            // Create the bitmap from the byte array.
            //
            MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length);
            ms.Write(imgData, 0, imgData.Length);
            image = Image.FromStream(ms, true);

            // Create the bound rectangle.
            //
            int top = BitConverter.ToInt32(topPosData, 0);
            int bot = BitConverter.ToInt32(botPosData, 0);
            int left = BitConverter.ToInt32(leftPosData, 0);
            int right = BitConverter.ToInt32(rightPosData, 0);
            int width = right - left + 1;
            int height = bot - top + 1;
            bounds = new Rectangle(left, top, width, height);

            // Create a Guid
            //
            id = new Guid(idData);
        }
    
    }
}
