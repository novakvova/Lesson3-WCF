using System.Windows;
using System.ServiceModel;
using ContractLibrary;

// ХОСТ

namespace Hoster
{
    public partial class WindowHost : Window
    {
        // Канал связи с клиентом.
        public static IContractClient callback;

        // Хостинг для сервиса.
        private ServiceHost host;

        // Конструктор.
        public WindowHost()
        {
            InitializeComponent();

            // Создание хостинга для сервиса.
            host = new ServiceHost(typeof(MyService));

            // Добавление конечной точки.
            host.AddServiceEndpoint(typeof(IContractService), new NetTcpBinding(), 
                "net.tcp://localhost:9000/MyService");

            // Запуск хоста.
            host.Open();
        }

        // Вызов метода на клиенте.
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WindowHost.callback.ClientMethod(textBox1.Text);
        }
    }
}
