using System;
using System.ServiceModel;
using System.Threading;

// Тема: Наследование Контрактов.

namespace Client
{
    // КОНТРАКТЫ.

    [ServiceContract]
    interface IInterface1 //узкий интерфейс
    {
        [OperationContract]
        string Method1(string s);
    }

    [ServiceContract]
    interface IInterface2 : IInterface1 //шырокий интерфейс
    {
        [OperationContract]
        string Method2(string s);
    }


    class Program
    {
        static void Main()
        {
            Console.Title = "CLIENT";

            Thread.Sleep(2000);

            IInterface2 proxy = ChannelFactory<IInterface2>.CreateChannel(
                new BasicHttpBinding(), new EndpointAddress("http://localhost:1000"));
            
            using (proxy as IDisposable)
            {
                Console.WriteLine(proxy.Method1("Ping "));
                Console.WriteLine(proxy.Method2("Ping "));                             
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
