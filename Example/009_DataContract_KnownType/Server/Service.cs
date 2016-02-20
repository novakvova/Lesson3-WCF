using System;
using System.Windows.Forms;
using System.ServiceModel;
using System.Collections.Generic;

// СЕРВИС.

namespace Server
{    
    public class Service : IContactManager
    {
        List<Customer> m_Customers = new List<Customer>();
               
        public void AddCustomer(Customer customer)
        {
            m_Customers.Add(customer);
            //MessageBox.Show(OperationContext.Current.RequestContext.RequestMessage.ToString(), 
            //    "SERVER AddCustomer()" + " " + this.GetHashCode().ToString());            
        }
        
        public void AddContact(Contact contact)
        {
            m_Customers.Add(contact as Customer);
            //MessageBox.Show(OperationContext.Current.RequestContext.RequestMessage.ToString(), 
            //    "SERVER AddContact()" + " " + this.GetHashCode().ToString());
        }

        public Contact[] GetContacts()
        {
            //MessageBox.Show(OperationContext.Current.RequestContext.RequestMessage.ToString(), 
            //    "SERVER GetContacts()" + " " + this.GetHashCode().ToString());
            return m_Customers.ToArray();
        }
    }
}
