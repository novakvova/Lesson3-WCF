using System;
using System.ServiceModel;

// Тема: Наследование Контрактов.

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
            Console.Title = "SERVER";

            IInterface1 proxy1 = ChannelFactory<IInterface1>.CreateChannel(
                new BasicHttpBinding(), new EndpointAddress("http://localhost:80/A"));
            IInterface2 proxy2 = ChannelFactory<IInterface2>.CreateChannel(
                new BasicHttpBinding(), new EndpointAddress("http://localhost:80/B"));

            using (proxy1 as IDisposable)
            {
                Console.WriteLine(proxy1.Method1("Ping -> ") + "\n");                
            }
            
            using (proxy2 as IDisposable)
            {
                Console.WriteLine(proxy2.Method1("Ping -> "));
                Console.WriteLine(proxy2.Method2("Ping -> "));
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
