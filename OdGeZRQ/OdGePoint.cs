using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.Core;

namespace OdGeZRQ
{
    internal class OdGePoint
    {
        OdGePoint2d GePoint2D;
        OdGePoint3d GePoint3D;

        public static void TestOdGePoint()
        {
            OdGePoint2d defaultPoint2d = new OdGePoint2d();
            Console.WriteLine($"OdGePoint2d默认构造{defaultPoint2d}");
        }
    }
}
