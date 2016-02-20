using System.ServiceModel;

// Тема: Наследование Контрактов.

namespace CientService
{
    // КОНТРАКТЫ.

    [ServiceContract]
    interface IInterface1
    {
        [OperationContract]
        string Method1(string s);        
    }

    [ServiceContract]
    interface IInterface2 : IInterface1
    {
        [OperationContract]
        string Method2(string s);
    }


    // СЕРВИС.

    class MyService : IInterface1, IInterface2
    {
        // Реализация IInterface1
        public string Method1(string s)
        {
            return s + " Контракт - IInterface1";
        }

        // Реализация IInterface2
        public string Method2(string s)
        {
            return s + " Контракт - IInterface2";
        }
    }
}
