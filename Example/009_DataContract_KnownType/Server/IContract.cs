using System.ServiceModel;
using System.Runtime.Serialization;

// КОНТРАКТЫ.

namespace Server
{
    // СЕРВИСНЫЙ КОНТРАКТ.
    [ServiceContract]
    public interface IContactManager
    {
        [OperationContract]
        void AddCustomer(Customer customer);
        [OperationContract]
        void AddContact(Contact contact);
        [OperationContract]
        Contact[] GetContacts();
    }


    // КОНТРАКТЫ ДАННЫХ.

    [DataContract(Namespace = "OtherNamespace")]
    [KnownType(typeof(Customer))]
    public class Contact
    {
        [DataMember]
        public string FirstName;
        [DataMember]
        public string LastName;
    }

    [DataContract(Namespace = "OtherNamespace")]
    public class Customer : Contact
    {
        [DataMember]
        public int OrderNumber;
    }
}
