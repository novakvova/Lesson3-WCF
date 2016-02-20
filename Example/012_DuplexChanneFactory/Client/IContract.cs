using System;
using System.ServiceModel;

namespace Client
{
    // КОНТРАКТ (Для клиента)

    // Интерфейс для реализации метода на стороне клиента.
    public interface IClientContract
    {
        // IsOneWay = true - клиент не ожидает успешного завершения метода на сервисе.
        [OperationContract(IsOneWay = true)]
        void ClientMethod(string message);
    }

    //=======================================================================

    // КОНТРАКТ (Для сервиса)
    
    // Когда служба используется для дуплексного обмена сообщениями, 
    // свойство CallbackContract определяет контракт, реализованный клиентом.
    [ServiceContract(CallbackContract = typeof(IClientContract))]
    public interface IServiceContract
    {
        // IsOneWay = true - сервис не ожидает успешного завершения метода на клиенте.
        [OperationContract(IsOneWay = true)]
        void ServiceMethod();
    }
}
