using static 建议44_委托协变.Program;

namespace 建议44_委托协变
{
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

    internal class Program
    {
        public delegate T GetEmployeeHanlder<out T>(string name);

        static void Main()
        {
            //GetEmployeeHanlder<Employee> getAEmployee = GetAManager;
            //Employee e = getAEmployee("Mike");

            GetEmployeeHanlder<Manager> getAManager = GetAManager;
            GetEmployeeHanlder<Employee> getAEmployee = getAManager;
        }

        static Manager GetAManager(string name)
        {
            Console.WriteLine("我是经理:" + name);
            return new Manager() { Name = name };
        }

        static Employee GetAEmployee(string name)
        {
            Console.WriteLine("我是雇员:" + name);
            return new Employee() { Name = name };
        }
    }
}