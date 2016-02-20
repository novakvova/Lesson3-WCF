using System;
using System.ServiceModel;

namespace Client
{
    class Context : IClientContract
    {
        public void ClientMethod(string message)
        {
            Console.WriteLine(message);
        }
    }
}
