using System.ComponentModel;

namespace ImpCtrlClientManager
{
    public interface IManageList<T>
    {
        void SaveList(BindingList<T> serverList);

        BindingList<T> ReadList();
    }
}
