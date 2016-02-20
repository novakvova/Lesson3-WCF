using System;
using System.Windows;
using System.ServiceModel;

namespace Server
{
    public partial class Window1 : Window
    {
        Uri address = new Uri("http://localhost:4000/IContract");
        WSHttpBinding binding = new WSHttpBinding();
        ServiceHost service = null;
               
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (service == null)
                {                       
                    service = new ServiceHost(typeof(CalculatorService));
                    service.AddServiceEndpoint(typeof(ICalculator), binding, address);                    
                    service.Open();
                    textBox1.Text += "Сервер запущен.         " + DateTime.Now + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (service != null)
                {                    
                    service.Close();
                    service = null;
                    textBox1.Text += "Сервер остановлен.    " + DateTime.Now + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
