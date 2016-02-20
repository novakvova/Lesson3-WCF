using System;
using System.Windows;
using System.ServiceModel;

// КЛИЕНТ.

namespace Client
{
    public partial class Window1 : Window
    {
        Uri address = new Uri("http://localhost:4000/IContract");
        BasicHttpBinding binding = new BasicHttpBinding();
        ChannelFactory<IContract> factory = null;
        IContract channel = null;

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
                    factory = new ChannelFactory<IContract>(binding, new EndpointAddress(address));
                    channel = factory.CreateChannel();
                }

                if (factory != null && channel != null)
                {
                    Point A = new Point(1, 1);
                    Point B = new Point(2, 2);

                    Point Res = channel.Add(A, B);                  

                    textBox1.Text = string.Format("Add({0} + {1}, {2} + {3}) = {4}  {5}", A.x, A.y, B.x, B.y, Res.x, Res.y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Реакция на изменение textBox1.
        private void textBox1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            textBox1.ScrollToEnd();
        }
    }
}
