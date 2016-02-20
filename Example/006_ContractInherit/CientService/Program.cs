using System;
using System.ServiceModel;

// Тема: Наследование Контрактов.

namespace CientService
{
    class Program
    {
        static void Main()
        {
            Console.Title = "SERVER";

            ServiceHost host = new ServiceHost(typeof(MyService));
            
            host.AddServiceEndpoint(typeof(IInterface1), new BasicHttpBinding(), "http://localhost:80/A");
            host.AddServiceEndpoint(typeof(IInterface2), new BasicHttpBinding(), "http://localhost:80/B");

            host.Open();

            Console.WriteLine("Хост открыт...");

            // Задержка.
            Console.ReadKey();

            host.Close();
        }
    }
}
