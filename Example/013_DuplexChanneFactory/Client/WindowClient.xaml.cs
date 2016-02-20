using System.Windows;
using System.ServiceModel;
using ContractLibrary;

// КЛИЕНТ

namespace Client
{
    public partial class WindowClient : Window
    {
        // Конструктор.
        public WindowClient()
        {
            InitializeComponent();
        }

        // Обработчик кнопки.
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // InstanceContext - представляет метод вызываемый сервисом на клиенте.
            InstanceContext context = new InstanceContext(new Context(this));

            // Создаем фабрику дуплексных каналов на клиенте.
            DuplexChannelFactory<IContractService> factory = new DuplexChannelFactory<IContractService>
                (context, new NetTcpBinding(), "net.tcp://localhost:9000/MyService");

            // Создаем конкретный канал.
            IContractService server = factory.CreateChannel();

            // Получаем текущий канал связи с клиентом.
            server.ServiceMethod();

            textBox1.Text = "connected";
        }
    }
}
