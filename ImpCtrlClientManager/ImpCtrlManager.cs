using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace ImpCtrlClientManager
{
    public class ImpCtrlManger
    {
        private readonly BindingList<ImpCtrlServer> _listManger;
        private readonly IManageList<ImpCtrlServer> _serverManagerList = new XmlManageList<ImpCtrlServer>();

        public event Action<string> UpdateLog;

        public ImpCtrlManger()
        {
            _listManger = _serverManagerList.ReadList();
            _listManger.ListChanged += OnListChange;
        }

        public void SaveServerList()
        {
            if (!IsServerListChanged) return;

            _serverManagerList.SaveList(_listManger);
            WriteLog("Список серверов сохранен!");
            IsServerListChanged = false;
        }

        public void AddServer()
        {
            _listManger.Add(new ImpCtrlServer()
            {
                Description = "LocalHost",
                IpAdress = "localhost",
                NeedWatch = false
            });
            WriteLog("Добавили новый сервер");
        }

        public void DeleteServer(int serverIndex)
        {
            try
            {
                _listManger.RemoveAt(serverIndex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException.Message);
            }
            WriteLog("Удалили сервер");
        }

        public bool IsServerListChanged
        {
            get;
            private set;
        }

        private void OnListChange(object sender, ListChangedEventArgs e)
        {
            try
            {

                if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
                {
                    IsServerListChanged = true;
                }

                if (!e.PropertyDescriptor.Attributes.OfType<XmlIgnoreAttribute>().Any())
                {
                    IsServerListChanged = true;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        public BindingList<ImpCtrlServer> GetServerList()
        {
            return _listManger;
        }

        public void ConnectToService()
        {
            WriteLog("Подключаемся к серверам...");
            foreach (var manager in _listManger.Where(x=>x.NeedWatch))
            {
                manager.RegisterCallbackFuncToService();
            }
        }

        public void GetScreenShotByIndex(int serverIndex)
        {
             _listManger[serverIndex].GetScreenshotImageFromWcf();
        }

        public string[] GetFullLogWork(int serverIndex)
        {
            return _listManger[serverIndex].GetFullLogFromServer();
        }

        public string GetImportProtocolByServer(int serverIndex)
        {
            return _listManger[serverIndex].GetImportProtocol();
        }

        public string GetServerNameByIndex(int serverIndex)
        {
            return _listManger[serverIndex].Description;
        }

        private void WriteLog(string info)
        {
            if (UpdateLog != null) UpdateLog(String.Format("[{0}] {1}", DateTime.Now, info));
        }

        public void Disconnect()
        {
            WriteLog("Отключаемся от серверов");
            foreach (var manager in _listManger.Where(x => x.NeedWatch))
            {
                manager.DisconnectFromWcfService();
            }
        }

        public void GetStatus()
        {
            WriteLog("Запрашиваем статус от серверов...");
            foreach (var manager in _listManger.Where(x => x.NeedWatch))
            {
                manager.GetLastStatusFromWcfAsync();
            }
        }
    }
}
