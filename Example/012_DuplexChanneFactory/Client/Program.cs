using System;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Client";

            // InstanceContext - представляет метод вызываемый сервисом на клиенте.
            InstanceContext context = new InstanceContext(new Context());
            
            // Создаем фабрику дуплексных каналов на клиенте.
            DuplexChannelFactory<IServiceContract> factory = 
                new DuplexChannelFactory<IServiceContract>(context, new NetTcpBinding(), 
                    "net.tcp://localhost:9000/MyService"); //ABCC

            // Создаем конкретный канал.
            IServiceContract proxy = factory.CreateChannel();

            Console.WriteLine("Нажмите Enter для вызова метода на сервере.");
            Console.ReadKey();

            // Вызов метода на сервере для получения канала для общения с клиентом.
            proxy.ServiceMethod();

            // Задержка.
            Console.ReadKey();
        }
    }
}
