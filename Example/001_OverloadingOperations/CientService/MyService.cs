using System;
using System.ServiceModel;

// Тема: Перегрузка Методов при работе с сервисами.

// В WCF - перегрузка НЕДОПУСТИМА! 
// (Исключение InvalidOperationException)

// Существует возможность организовать перегрузку вручную, 
// указав в свойстве Name атрибута OperationContract псевдоним операции.
// Псевдоним должен быть определен как на стороне службы, 
// так и на стороне сервиса.

namespace CientService
{
    // КОНТРАКТ.

    [ServiceContract]
    interface IInterface
    {
        [OperationContract(Name = "AddInt")]
        int Add(int a, int b);

        [OperationContract(Name = "AddDouble")]
        double Add(double a, double b);
    }

    // СЕРВИС.

    class MyService : IInterface
    {
        public int Add(int a, int b)
        {
            //Виводимо soap формат
            Console.WriteLine(OperationContext.Current.RequestContext.RequestMessage.ToString() + "\n");
            return a + b;
        }

        public double Add(double a, double b)
        {
            //Виводимо soap формат
            Console.WriteLine(OperationContext.Current.RequestContext.RequestMessage.ToString() + "\n");
            return a + b;
        }
    }
}
