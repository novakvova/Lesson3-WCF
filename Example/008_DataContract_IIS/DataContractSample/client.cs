using System;
using System.ServiceModel;

namespace My
{
    class Client
    {
        static void Main()
        {
            CalculatorClient calc = new CalculatorClient();

            Point A = new Point();
            A.x = 1;
            A.y = 1;

            Point B = new Point();
            B.x = 2;
            B.y = 2;

            Point Res = calc.Add(A, B);

            Console.WriteLine("Add({0} + {1}, {2} + {3}) = {4}  {5}", A.x, A.y, B.x, B.y, Res.x, Res.y);

            calc.Close();

            // Задержка.
            Console.ReadKey();
        }
    }
}
