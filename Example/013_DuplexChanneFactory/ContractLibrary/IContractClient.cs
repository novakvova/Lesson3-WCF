using System;
using System.ServiceModel;

// КОНТРАКТ (Для клиента)

namespace ContractLibrary
{
    //Интерфейс для реализации метода на стороне клиента.
    public interface IContractClient
    {
        // IsOneWay = true - клиент не ожидает успешного завершения метода на сервисе.
        [OperationContract(IsOneWay = true)]
        void ClientMethod(string message);
    }
}
