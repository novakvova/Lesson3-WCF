using System;
using System.ServiceModel;

// Тема: Перегрузка Методов при работе с сервисами.

// В WCF - перегрузка НЕДОПУСТИМА! (Исключение InvalidOperationException)

// Существует возможность организовать перегрузку вручную, 
// указав в свойстве Name атрибута OperationContract псевдоним операции.
// Псевдоним должен быть определен как на стороне службы, так и на стороне сервиса.


// На стороне сервиса перегрузка отсутствует.

namespace CientService
{
    // КОНТРАКТ.

    [ServiceContract]
    interface IInterface
    {
        [OperationContract]
        int AddInt(int a, int b);

        [OperationContract]
        double AddDouble(double a, double b);
    }

    // СЕРВИС.

    class MyService : IInterface
    {
        public int AddInt(int a, int b)
        {
            Console.WriteLine(OperationContext.Current.RequestContext.RequestMessage.ToString() + "\n");
            return a + b;
        }

        public double AddDouble(double a, double b)
        {
            Console.WriteLine(OperationContext.Current.RequestContext.RequestMessage.ToString() + "\n");
            return a + b;
        }
    }
}
