using System.ServiceModel;
using System.Runtime.Serialization;

namespace My
{
    // СЕРВИСНЫЙ КОНТРАКТ.
    [ServiceContract(Namespace = "http://My")]
    public interface IContract
    {
        [OperationContract]
        Point Add(Point a, Point b);
    }

    // КОНТРАКТ ДАННЫХ.
    [DataContract(Namespace = "http://My")]
    public class Point
    {
        [DataMember]
        public double x;

        [DataMember]
        public double y;

        public Point(double real, double imaginary)
        {
            this.x = real;
            this.y = imaginary;
        }
    }

    // СЕРВИС.
    public class Service : IContract
    {
        public Point Add(Point n1, Point b)
        {
            return new Point(n1.y + n1.x, b.y + b.x);
        }
    }
}
