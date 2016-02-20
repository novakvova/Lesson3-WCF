using System.ServiceModel;
using System.Runtime.Serialization;

// КОНТРАКТЫ.

namespace Server
{
    // СЕРВИСНЫЙ КОНТРАКТ.
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        Point Add(Point a, Point b);
    }

    // КОНТРАКТ ДАННЫХ.
    [DataContract(Namespace = "OtherNamespace")]   
    public class Point
    {
        [DataMember]
        public double x;
        [DataMember]
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
