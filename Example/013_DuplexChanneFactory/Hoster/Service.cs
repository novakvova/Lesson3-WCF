using System.ServiceModel;
using ContractLibrary;

// СЕРВИС

namespace Hoster
{
    class MyService : IContractService
    {       
        // Получение текущего канала связи с клиентом.
        public void ServiceMethod()
        {
            // Интерфейсная ссылка ICallbackMessage.
            WindowHost.callback = 
                OperationContext.Current.GetCallbackChannel<IContractClient>();
        }  
    }
}
