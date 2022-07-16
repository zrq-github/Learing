using System;

namespace 建议42
{
    interface ISalary<out T>
    {
        void Pay();
    }

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
    class Programmer : Employee
    {
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

        static void PrintSalary(ISalary<Employee> s)
        {
            s.Pay();
        }
    }
}