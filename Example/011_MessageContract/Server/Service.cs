using System;
using System.Windows.Forms;
using System.ServiceModel;
using System.Collections.Generic;

// СЕРВИС.

namespace Server
{
    public class CalculatorService : ICalculator
    {
        public MyMessage Calculate(MyMessage request)
        {
            MyMessage response = new MyMessage(request);

            switch (request.Operation)
            {
                case "+":
                    response.Result = request.N1 + request.N2;
                    break;
                case "-":
                    response.Result = request.N1 - request.N2;
                    break;
                case "*":
                    response.Result = request.N1 * request.N2;
                    break;
                case "/":
                    response.Result = request.N1 / request.N2;
                    break;
                default:
                    response.Result = 0.0D;
                    break;
            }
            return response;
        }
    }
}
