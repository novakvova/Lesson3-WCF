using System;
using System.ServiceModel;

// Тема: Перегрузка Методов при работе с сервисами.

namespace CientService
{
    class Program
    {
        static void Main()
        {
            Console.Title = "SERVER";

            ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:1000"));
            host.AddServiceEndpoint(typeof(IInterface), new BasicHttpBinding(), "");
            host.Open();

            Console.WriteLine("Хост открыт...");

            // Задержка.
            Console.ReadKey();

            host.Close();
        }
    }
}
