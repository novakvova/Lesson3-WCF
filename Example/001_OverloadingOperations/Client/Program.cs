using System;
using System.ServiceModel;

// Тема: Перегрузка Методов при работе с сервисами.

namespace Client
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


    class Program
    {
        static void Main()
        {
            Console.Title = "CLIENT";

            IInterface proxy = ChannelFactory<IInterface>.CreateChannel(
                new BasicHttpBinding(), new EndpointAddress("http://localhost:1000"));
            
            using (proxy as IDisposable)
            {
                int i = proxy.Add(2, 3);
                Console.WriteLine(i);

                double d = proxy.Add(2.2, 3.3);
                Console.WriteLine(d);                
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
