using System;
using System.ServiceModel;
using System.Threading;

// Тема: Перегрузка Методов при работе с сервисами.

namespace Client
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
    
    class Program
    {
        static void Main()
        {
            Console.Title = "CLIENT";
            Thread.Sleep(2000);

            IInterface1 proxy1 = ChannelFactory<IInterface1>.CreateChannel(
                new BasicHttpBinding(), new EndpointAddress("http://localhost:80"));
            IInterface2 proxy2 = ChannelFactory<IInterface2>.CreateChannel(
                new BasicHttpBinding(), new EndpointAddress("http://localhost:81"));

            using (proxy1 as IDisposable)
            {
                Console.WriteLine(proxy1.Method1("Ping ") + "\n");                             
            }
                        
            using (proxy2 as IDisposable)
            {
                Console.WriteLine(proxy2.Method1("Ping "));
                Console.WriteLine(proxy2.Method2("Ping "));
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
