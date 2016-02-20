using System;
using System.ServiceModel;

// КОНТРАКТ (Для сервиса)

namespace ContractLibrary
{
    // Интерфес для сервера.
 
    // Когда служба используется для дуплексного обмена сообщениями, 
    // свойство CallbackContract определяет контракт, реализованный клиентом.
    [ServiceContract(CallbackContract=typeof(IContractClient))]
    public interface IContractService
    {
        // IsOneWay = true - сервис не ожидает успешного завершения метода на клиенте.
        [OperationContract(IsOneWay=true)]
        void ServiceMethod();
    }
}
