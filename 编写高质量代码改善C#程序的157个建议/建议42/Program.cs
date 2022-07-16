using System;

namespace 建议42
{
    interface ISalary<T> { void Pay(); }

    class BaseSalaryCounter<T> : ISalary<T>
    {
        public void Pay()
        {
            Console.WriteLine("Pay base salary");
        }
    }

    class Employee
    {
        public string Name { get; set; }
    }

    class Manager : Employee
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISalary<Programmer> s = new BaseSalaryCounter<Programmer>();
            PrintSalary(s);
        }

        /// <summary>
        /// 编译错误
        /// </summary>
        /// <remarks>
        /// 因为 Programmer Manager 都是继承 Employee 所以我们会很正常的这么写, 但是其实是编译错误的.
        /// </remarks>
        static void PrintSalary(ISalary<Employee> s)
        {
            s.Pay();
        }

        /// <summary>
        /// 编译正确
        /// </summary>
        //static void PrintSalary<T>(ISalary<T> s)
        //{
        //    s.Pay();
        //}
    }

    class Programmer : Employee
    {
    }
}