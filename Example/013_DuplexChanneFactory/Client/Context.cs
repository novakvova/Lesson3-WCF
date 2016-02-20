using System;
using ContractLibrary;

// КОНТЕКСТ (Клиентский сервис)

namespace Client
{
    class Context : IContractClient
    {
        private WindowClient window;

        // Конструктор.
        public Context(WindowClient window)
        {
            this.window = window;
        }

        // Метод который вызывается сервисом на клиенте.
        public void ClientMethod(string message)
        {
            // Выводим строку, которую прислал сервис.
            window.textBox1.Text = message;
        }
    }
}
