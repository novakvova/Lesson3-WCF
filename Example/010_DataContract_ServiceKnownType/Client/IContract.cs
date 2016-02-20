using System.ServiceModel;
using System.Runtime.Serialization;

// КОНТРАКТЫ.

namespace Client
{
    // СЕРВИСНЫЙ КОНТРАКТ.
    [ServiceContract]
    public interface IContactManager
    {       
        [OperationContract]
        [ServiceKnownType(typeof(Customer))]
        void AddContact(Contact contact);

        [OperationContract]
        [ServiceKnownType(typeof(Customer))]
        Contact[] GetContacts();
    }


    // КОНТРАКТЫ ДАННЫХ.

    [DataContract(Namespace = "OtherNamespace")]
    //[KnownType(typeof(Customer))]
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
