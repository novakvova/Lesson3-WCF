using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Diagnostics;

[assembly: ContractNamespaceAttribute("http://My", ClrNamespace = "My")]

namespace My
{
    [DataContractAttribute()]
    public partial class Point : object, IExtensibleDataObject
    {

        private double _y;
        private double _x;

        private ExtensionDataObject extensionDataField;
        public ExtensionDataObject ExtensionData
        {
            get { return this.extensionDataField; }
            set { this.extensionDataField = value; }
        }

        [DataMemberAttribute()]
        public double y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        [DataMemberAttribute()]
        public double x
        {
            get { return this._x; }
            set { this._x = value; }
        }
    }

    [ServiceContractAttribute(Namespace = "http://My", ConfigurationName = "My.IContract")]
    public interface IContract
    {
        [OperationContractAttribute(Action = "http://My/IContract/Add", ReplyAction = "http://My/IContract/AddResponse")]
        Point Add(Point a, Point b);
    }

    public interface IDataContractCalculatorChannel : IContract, IClientChannel
    {
    }

    public partial class CalculatorClient : ClientBase<IContract>, IContract
    {
        public CalculatorClient() { }

        public CalculatorClient(string endpointConfigurationName) :
            base(endpointConfigurationName) { }

        public CalculatorClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress) { }

        public CalculatorClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress) { }

        public CalculatorClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress) { }

        public Point Add(Point a, Point b)
        {
            return base.Channel.Add(a, b);
        }
    }
}

