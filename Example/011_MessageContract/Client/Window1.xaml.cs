using System;
using System.Windows;
using System.ServiceModel;

// КЛИЕНТ.

namespace Client
{
    public partial class Window1 : Window
    {
        Uri address = new Uri("http://localhost:4000/IContract");
        WSHttpBinding binding = new WSHttpBinding();
        ChannelFactory<ICalculator> factory = null;
        ICalculator channel = null;

        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (factory == null)
                {
                    factory = new ChannelFactory<ICalculator>(binding, new EndpointAddress(address));
                    channel = factory.CreateChannel();
                }

                if (factory != null && channel != null)
                {
                    // Сложение.
                    MyMessage request = new MyMessage();
                    request.N1 = 100D;
                    request.N2 = 15.99D;
                    request.Operation = "+";
                    MyMessage response = channel.Calculate(request);
                    textBox1.Text += string.Format("Add({0},{1}) = {2}", 
                        request.N1, request.N2, response.Result) + Environment.NewLine;

                    // Вычитание.
                    request = new MyMessage();
                    request.N1 = 145D;
                    request.N2 = 76.54D;
                    request.Operation = "-";
                    response = channel.Calculate(request);
                    textBox1.Text += string.Format("Subtract({0},{1}) = {2}", 
                        request.N1, request.N2, response.Result) + Environment.NewLine;

                    // Умножение.
                    request = new MyMessage();
                    request.N1 = 9D;
                    request.N2 = 81.25D;
                    request.Operation = "*";
                    response = channel.Calculate(request);
                    textBox1.Text += string.Format("Multiply({0},{1}) = {2}", 
                        request.N1, request.N2, response.Result) + Environment.NewLine;

                    // Деление.
                    request = new MyMessage();
                    request.N1 = 22D;
                    request.N2 = 7D;
                    request.Operation = "/";
                    response = channel.Calculate(request);
                    textBox1.Text += string.Format("Divide({0},{1}) = {2}", 
                        request.N1, request.N2, response.Result) + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CLIENT");
            }
        }
    }
}
