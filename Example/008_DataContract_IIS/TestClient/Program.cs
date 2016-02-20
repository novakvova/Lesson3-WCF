using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.ServiceReference1;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ContractClient service = new ContractClient();
            Point a = new Point();
            Point b= new Point();
            a.x = 1;
            a.y = 1;
            b.x = 2;
            b.y = 2;
            Point c = service.Add(a, b);
            Console.WriteLine(c.x);
            Console.ReadKey();
        }
    }
}
