using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.Core;

namespace OdGeZRQ
{
    internal class TOdGePoint
    {
        OdGePoint2d GePoint2D;
        OdGePoint3d GePoint3D;

        public static void TestOdGePoint()
        {
            OdGePoint2d odGePoint2D = new OdGePoint2d();
            Console.WriteLine($"OdGePoint2d 默认构造数据 {odGePoint2D}");

            OdGeVector2d odGeVector2D = new OdGeVector2d();
            Console.WriteLine($"OdGeVector2d 默认构造数据 {odGePoint2D}");

            OdGePoint2d resultPoint2D = new OdGePoint2d();
            OdGePoint2d odGePoint2D1 = new OdGePoint2d();
            Console.WriteLine($"测试 OdGePoint2d Add(OdGeVector2d vect)");
            odGePoint2D = new OdGePoint2d(0, 0);
            odGeVector2D = new OdGeVector2d(5, 5);
            resultPoint2D = odGePoint2D.Add(odGeVector2D);
            Console.WriteLine($"结论: \n" +
                $"Add 加法运算，等同于 点 按照向量的方向和大小 进行移动");

            odGePoint2D = new OdGePoint2d(0, 0);
            odGePoint2D1 = new OdGePoint2d(10, 0);
            double dist = odGePoint2D.distanceTo(odGePoint2D1);
            double sqrtDist = odGePoint2D.distanceSqrdTo(odGePoint2D1);

            odGePoint2D = new OdGePoint2d(10, 5);
            resultPoint2D = odGePoint2D.Div(5);
            resultPoint2D = odGePoint2D.Mul(5);
            Console.WriteLine($"结论: \n" +
                $"Div Mul 单纯的除法 乘法");

            Console.WriteLine($"测试 GetItem Add(OdGeVector2d vect)");
            double item0 = odGePoint2D.GetItem(0);
            double item1 = odGePoint2D.GetItem(1);
            double item2 = odGePoint2D.GetItem(2);
            OdGePoint3d odGePoint3D = new OdGePoint3d(1, 2, 3);
            item0 = odGePoint3D.GetItem(0);
            item1 = odGePoint3D.GetItem(1);
            item2 = odGePoint3D.GetItem(2);
            double item3 = odGePoint3D.GetItem(3);
            Console.WriteLine($"结论: \n" +
                $"GetItem(uint i)这个函数有点奇怪。" +
                $"虽然后面的多填不会抛异常，但是会出现无效数值" +
                $"对于OdGePoint2d GetItem(0) GetItem(1) 就是其x,y");

            odGePoint2D = new OdGePoint2d(10, 10);
            OdGeLine2d odGeLine2D = new OdGeLine2d(new OdGePoint2d(0, 0), new OdGePoint2d(5, 5));
            resultPoint2D = odGePoint2D.mirror(odGeLine2D);

            odGePoint2D = new OdGePoint2d(10, 10);
            resultPoint2D = odGePoint2D.rotateBy(Math.PI);
            odGePoint2D = new OdGePoint2d(10, 10);
            resultPoint2D = odGePoint2D.rotateBy(Math.PI, new OdGePoint2d(10, 0));
            Console.WriteLine($"结论: \n" +
                $"odGePoint2D 创建的时候是(10, 10) ，经过 绕原点90°后，（-10,10） 是右手定则。" +
                $"但是 原始的 odGePoint2D 是发生了变换。 没有像前面的函数调用后，是没有发生变换的");

            odGePoint2D = new OdGePoint2d(10, 10);
            resultPoint2D = odGePoint2D.scaleBy(-0.2);
            odGePoint2D = new OdGePoint2d(10, 10);
            odGePoint2D1 = new OdGePoint2d(-3, -5);
            resultPoint2D = odGePoint2D.scaleBy(4, odGePoint2D1);
            Console.WriteLine($"结论: \n" +
                $"推测 scaleBy 的公式： \n" +
                $"R_X = (O_X - B_X) * scaleFactor + B_X \n" +
                $"R_Y = (O_Y - B_Y) * scaleFactor + B_Y");

            odGePoint2D = new OdGePoint2d(10, 10);
            resultPoint2D = odGePoint2D.set(20, 20);

            odGePoint2D = new OdGePoint2d(10, 10);
            resultPoint2D = odGePoint2D.setToSum(odGePoint2D, new OdGeVector2d(20, 20));
        }
    }
}
