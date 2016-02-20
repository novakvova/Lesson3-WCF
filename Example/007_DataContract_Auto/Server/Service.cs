using System;
using System.Windows.Forms;
using System.ServiceModel;

// СЕРВИС.

namespace Server
{
    public class Service : IContract
    {
        public Point Add(Point a, Point b)
        {
            //MessageBox.Show(OperationContext.Current.RequestContext.RequestMessage.ToString());
            return new Point(a.y + a.x, b.y + b.x);
        }
    }
}
