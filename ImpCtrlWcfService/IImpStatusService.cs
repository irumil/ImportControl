using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;

namespace ImpCtrlWcfService
{
    [ServiceContract(CallbackContract = typeof(IImpStatusServiceCallback))]
    public interface IImpStatusService
    {
        [OperationContract]
        void RegistrCallbackClientFunc();

        [OperationContract]
        string GetLastSatus();

        [OperationContract]
        Image GetImageStatus();

        [OperationContract]
        byte[] GetScreenshot();

        [OperationContract]
        List<string> GetFullLog();

        [OperationContract]
        string GetImportProtocol();
    }

    public interface IImpStatusServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnStatusComplete(string message);
    }
    
}
