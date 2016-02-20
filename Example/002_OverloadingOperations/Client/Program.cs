using System;
using System.ServiceModel;

// Тема: Перегрузка Методов при работе с сервисами.

// На клиенте перегрузка отсутствует.

namespace Client
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


    class Program
    {
        static void Main()
        {
            Console.Title = "CLIENT";

            IInterface proxy = ChannelFactory<IInterface>.CreateChannel(
                new BasicHttpBinding(), new EndpointAddress("http://localhost:1000"));
            
            using (proxy as IDisposable)
            {
                int i = proxy.AddInt(2, 3);
                Console.WriteLine(i);

                double d = proxy.AddDouble(2.2, 3.3);
                Console.WriteLine(d);                
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
