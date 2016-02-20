using System.ServiceModel;
using System.Runtime.Serialization;

// КОНТРАКТЫ.

namespace Client
{
    // СЕРВИСНЫЙ КОНТРАКТ.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        MyMessage Calculate(MyMessage request);
    }

    // КОНТРАКТ СООБЩЕНИЯ.
    [MessageContract]
    public class MyMessage
    {
        private string operation;
        private double n1;
        private double n2;
        private double result;

        // Constructor - создает пустое сообщение.
        public MyMessage() { }

        // Constructor - создает сообщение и заполняет его.
        public MyMessage(double n1, double n2, string operation, double result)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.operation = operation;
            this.result = result;
        }

        // Constructor - создает сообщение на основе другого сообщения.
        public MyMessage(MyMessage message)
        {
            this.n1 = message.n1;
            this.n2 = message.n2;
            this.operation = message.operation;
            this.result = message.result;
        }

        [MessageHeader]
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        [MessageBodyMember]
        public double N1
        {
            get { return n1; }
            set { n1 = value; }
        }

        [MessageBodyMember]
        public double N2
        {
            get { return n2; }
            set { n2 = value; }
        }

        [MessageBodyMember]
        public double Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
