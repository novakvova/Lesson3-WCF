using System;
using System.ServiceModel;

namespace Duplex
{
    // СЕРВИС.
    class Service : IServiceContract
    {
        public void ServiceMethod()
        {
            Console.WriteLine("ServiceMethod");

            Program.callback = 
                OperationContext.Current.GetCallbackChannel<IClientContract>();
        }
    }
}
