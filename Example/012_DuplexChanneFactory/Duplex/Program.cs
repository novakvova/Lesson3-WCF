using System;
using System.ServiceModel;

namespace Duplex
{
    class Program
    {
        public static IClientContract callback;

        static void Main()
        {
            Console.Title = "Server";
           
            // Создание хостинга для сервиса.
            ServiceHost host = new ServiceHost(typeof(Service));

            // Добавление конечной точки. 
            host.AddServiceEndpoint(typeof(IServiceContract), new NetTcpBinding(), 
                "net.tcp://localhost:9000/MyService");

            // Запуск хоста.
            host.Open();

            Console.WriteLine("Нажмите Enter для вызова метода на клиенте.");
            Console.ReadKey();

            // Вызов метода на клиенте.
            Program.callback.ClientMethod("Hello world!");

            // Задержка.
            Console.ReadKey();
        }
    }
}
