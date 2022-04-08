using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.Core;

namespace OdGeZRQ
{
    internal class OdGeLine
    {
        public OdGeLine2d OdGeLine2D;
        public OdGeLine3d OdGeLine3D;

        public static void TestOdGeLine()
        {
            OdGePoint2d odGePoint2D_x = new OdGePoint2d(0, 10);
            OdGePoint2d odGePoint2D_y = new OdGePoint2d(10, 0);

            OdGeLine2d odGeLine2D_x = new OdGeLine2d(odGePoint2D_x, new OdGeVector2d(1, 0));
            OdGeLine2d odGeLine2D_y = new OdGeLine2d(odGePoint2D_y, new OdGeVector2d(0, 1));

            Console.WriteLine($"测试线线相交");
            OdGePoint2d intersectPoint = new OdGePoint2d();
            bool isIntersectWith = odGeLine2D_x.intersectWith(odGeLine2D_y, intersectPoint);
        }
    }
}
