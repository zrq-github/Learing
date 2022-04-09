using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.Core;

namespace OdGeZRQ
{
    internal class TOdGeLine
    {
        public OdGeLine2d OdGeLine2D;
        public OdGeLine3d OdGeLine3D;

        public static OdGeLine2d odGeLine2d1 = new OdGeLine2d();

        public static void TestOdGeLine()
        {
            OdGePoint2d odGePoint2D_x = new OdGePoint2d(0, 10);
            OdGePoint2d odGePoint2D_y = new OdGePoint2d(10, 0);

            OdGeLine2d odGeLine2D_x = new OdGeLine2d(odGePoint2D_x, new OdGeVector2d(10, 0));
            OdGeLine2d odGeLine2D_y = new OdGeLine2d(odGePoint2D_y, new OdGeVector2d(0, 1));

            Console.WriteLine($"测试线线相交");
            OdGePoint2d intersectPoint = new OdGePoint2d();
            bool isIntersectWith = odGeLine2D_x.intersectWith(odGeLine2D_y, intersectPoint);

            OdGeLine2d odGeLine2D = new OdGeLine2d(new OdGePoint2d(10, 10), new OdGeVector2d(1, 1));
            odGeLine2D.pointOnLine();
            Console.WriteLine($"pointOnLine() 返回此线性实体上的任意点。\n" +
                $"文档虽然说的是返回此线性实体上的任意点。\n" +
                $"但是我测试了一些，返回的固定值，就是创建直接的时候，所用的原点。");


            OdGeLine2d perpLine = new OdGeLine2d();
            odGeLine2D.getPerpLine(new OdGePoint2d(10, 10), perpLine);

            // area() 用不了
            odGeLine2D = new OdGeLine2d(new OdGePoint2d(10, 10), new OdGeVector2d(1, 1));
            OdGePoint2d odGePoint2D_S = new OdGePoint2d();
            OdGePoint2d odGePoint2D_E = new OdGePoint2d();
            //if (odGeLine2D.area(0, 10, out double area))
            //{

            //}

            odGeLine2D = new OdGeLine2d(new OdGePoint2d(10, 10), new OdGeVector2d(1, 1));
            OdGePoint2d point = odGeLine2D.closestPointTo(new OdGePoint2d(10000, 0));

            // 点到线的距离
            Console.WriteLine("测试 distanceTo");
            odGeLine2D = new OdGeLine2d(new OdGePoint2d(10, 10), new OdGeVector2d(1, 1));
            double distance = odGeLine2D.distanceTo(new OdGePoint2d(10, 10));
            Console.WriteLine("OdGeTol 对直线是没有什么影响的，看看线段");
            OdGeLineSeg2d odGeLineSeg2D = new OdGeLineSeg2d(new OdGePoint2d(0, 0), new OdGePoint2d(10, 0));
            distance = odGeLineSeg2D.distanceTo(new OdGePoint2d(12, 0));


            odGeLine2D = new OdGeLine2d(new OdGePoint2d(0, 0), new OdGeVector2d(1, 1));
            point = odGeLine2D.evalPoint(1);


            odGeLine2D = new OdGeLine2d(new OdGePoint2d(10, 10), new OdGeVector2d(1, 0));
            OdGePointOnCurve2d pntOnCrv = new OdGePointOnCurve2d();
            odGeLine2D.getClosestPointTo(new OdGePoint2d(0, 0), pntOnCrv);
            //point = pntOnCrv.point2d();     // 这里抛异常？为啥啊


            Console.WriteLine("测试 共享 平行");
            odGeLine2D = new OdGeLine2d(new OdGePoint2d(0, 0), new OdGeVector2d(1, 1));
            odGeLine2d1 = new OdGeLine2d(new OdGePoint2d(0, 0), new OdGeVector2d(-1, -1));
            bool isParallel = odGeLine2D.isParallelTo(odGeLine2D);
            bool isColinear = odGeLine2D.isColinearTo(odGeLine2D);


            Console.WriteLine("测试 点在线上");
            odGeLine2D = new OdGeLine2d(new OdGePoint2d(0, 0), new OdGeVector2d(1, 1));
        }
    }
}
