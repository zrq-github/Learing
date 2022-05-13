using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.Core;


namespace OdGeZRQ
{
    internal class TOdGePanel
    {
        public static OdGePlane odGePlane = new OdGePlane();

        public static void TestOdGePlane()
        {
            OdGePoint3d resultPoint3D = new OdGePoint3d();
            OdGeVector3d odGeVector3D_z = new OdGeVector3d(0, 0, 1);

            OdGePlane odGePlane_z0 = new OdGePlane(new OdGePoint3d(0, 0, 0), odGeVector3D_z);
            OdGePlane odGePlane_z10 = new OdGePlane(new OdGePoint3d(0, 0, 10), odGeVector3D_z);
            OdGePlane odGePlane_x10 = new OdGePlane(new OdGePoint3d(10, 0, 0), new OdGeVector3d(1, 0, 0));


            Console.WriteLine($"测试共面");
            odGePlane = new OdGePlane(new OdGePoint3d(0, 0, 0), odGeVector3D_z);
            bool isCoplanar = odGePlane_z0.isCoplanarTo(odGePlane);
            isCoplanar = odGePlane_z0.isCoplanarTo(odGePlane_z10);
            isCoplanar = odGePlane_z0.isCoplanarTo(odGePlane_x10);


            Console.WriteLine($"测试平行");
            bool isParallel = odGePlane_z0.isParallelTo(odGePlane);
            isParallel = odGePlane_z0.isParallelTo(odGePlane_z10);
            isParallel = odGePlane_z0.isParallelTo(odGePlane_x10);


            Console.WriteLine($"点在面的投影");
            OdGePoint3d odGePoint3D = new OdGePoint3d(30, 30, 30);
            resultPoint3D = odGePlane_z0.closestPointTo(odGePoint3D);
            if (odGePlane_z0.project(odGePoint3D, resultPoint3D))
            {

            }


            Console.WriteLine($"线在面的投影-zrq");
            odGePlane_z0 = new OdGePlane(new OdGePoint3d(0, 0, 0), new OdGeVector3d(0, 0, 1));
            OdGeLine3d odGeLine3D = new OdGeLine3d(new OdGePoint3d(0, 0, 0), new OdGeVector3d(1, 1, 1));
            OdGeVector3d projectDirection = new OdGeVector3d(1, 1, 1);
            OdGeEntity3d projectOdGeLine3d = odGeLine3D.orthoProject(odGePlane_z0);
            if (projectOdGeLine3d is OdGeLine3d)
            {

            }

            OdGeLineSeg3d odGeLineSeg3D = new OdGeLineSeg3d(new OdGePoint3d(0, 0, 0), new OdGePoint3d(10, 10, 10));
            OdGeEntity3d projectOdGeLineSeg3D = odGeLineSeg3D.orthoProject(odGePlane_z0);
            if(projectOdGeLineSeg3D is OdGeLineSeg3d)
            {

            }

        }
    }
}
