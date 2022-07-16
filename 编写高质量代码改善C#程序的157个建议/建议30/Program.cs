using System;
using System.Collections.Generic;
using System.Linq;

namespace 建议30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<Salary> companySalary = new List<Salary>()
            {
                new Salary() { Name = "Mike", BaseSalary = 3000, Bonus = 1000, Price = new Price(){ Value=1} },
                new Salary() { Name = "Rose", BaseSalary = 2000, Bonus = 4000,Price = new Price(){ Value=2} },
                new Salary() { Name = "Jeffry", BaseSalary = 1000, Bonus = 6000,Price = new Price(){ Value=3} },
                new Salary() { Name = "Steve", BaseSalary = 4000, Bonus = 3000,Price = new Price(){ Value=4} }
            };

            Console.WriteLine("默认比较器排序(按BaseSalary)：");
            companySalary.Sort();
            foreach (Salary item in companySalary)
            {
                Console.WriteLine(string.Format("Name:{0}\tBaseSalary:{1}\tBonus:{2}",
                item.Name, item.BaseSalary, item.Bonus));
            }

            Console.WriteLine("BonusComparer比较器排序(Bonus)：");
            companySalary.Sort(new BonusComparer());//默认比较器排序
            foreach (Salary item in companySalary)
            {
                Console.WriteLine(String.Format("Name:{0}\tBaseSaraly:{1}\tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }

            Console.WriteLine("LINQ排序(按BaseSalary)：");
            var orderByBaseSalary = from s in companySalary orderby s.BaseSalary select s;
            foreach (Salary item in orderByBaseSalary)
            {
                Console.WriteLine(String.Format("Name:{0}\tBaseSaraly:{1}\tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }

            Console.WriteLine("LINQ排序(按Bonus)：");
            var orderBonus = from cs in companySalary orderby cs.Bonus select cs;
            foreach (Salary item in orderBonus)
            {
                Console.WriteLine(String.Format("Name:{0}\tBaseSaraly:{1}\tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }


            Console.WriteLine("LINQ排序测试调用引用对象的 orderby：");
            var orderPrice = from op in companySalary orderby op.Price select op;
            foreach (Salary item in orderPrice)
            {
                Console.WriteLine(String.Format("Name:{0}\tBaseSaraly:{1}\tBonus:{2}\tPrice:{3}", item.Name, item.BaseSalary, item.Bonus,item.Price.Value));
            }

           // companySalary.OrderBy(o => o.Price);

            Console.Read();
        }
    }
}