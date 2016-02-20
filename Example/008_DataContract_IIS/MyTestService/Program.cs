using MyTestService.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestService
{
    class Program
    {
        static void Main(string[] args)
        {
            Point z = new Point();
            Point t = new Point();
            z.x = 1; z.y = 1;
            t.x = 2; t.y = 2;
            ContractClient my = new ContractClient();
            Point v = my.Add(z, t);
            Console.WriteLine(v.x + " " + v.y);

        }
    }
}
