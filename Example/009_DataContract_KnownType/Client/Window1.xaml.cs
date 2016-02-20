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
        ChannelFactory<IContactManager> factory = null;
        IContactManager channel = null;

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
                    factory = new ChannelFactory<IContactManager>(
                        binding, new EndpointAddress(address));
                    channel = factory.CreateChannel();
                }

                if (factory != null && channel != null)
                {
                    Customer customer = new Customer();
                    customer.FirstName = "Ivan";
                    customer.LastName = "Petrov";
                    customer.OrderNumber = 123;
                    channel.AddContact(customer as Contact);

                    Contact[] contacts = channel.GetContacts();

                    for (int i = 0; i < contacts.Length; i++)
                    {
                        textBox1.Text += "->" + contacts[i].FirstName 
                            + " " + contacts[i].LastName + Environment.NewLine; ;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CLIENT");
            }
        }
    }
}
