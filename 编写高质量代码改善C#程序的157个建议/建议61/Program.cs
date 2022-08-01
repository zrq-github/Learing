namespace 建议61
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int returnBelowFinally = TestIntReturnBelowFinally();
            Console.WriteLine($"TestIntReturnBelowFinally,{returnBelowFinally}");

            int returnInTry = TestIntReturnInTry();
            Console.WriteLine($"TestIntReturnInTry,{returnInTry}");

            User user = TestUserReturnInTry();
            Console.WriteLine($"TestIntReturnInTry,{user}");

            User user2 = TestUserReturnInTry2();
            Console.WriteLine($"TestIntReturnInTry,{user2}");

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }

        private static int TestIntReturnBelowFinally()
        {
            int i;
            try
            {
                i = 1;
            }
            finally
            {
                i = 2;
                Console.WriteLine("\t将int结果改为2，finally执行完毕");
            }
            return i;
        }

        private static int TestIntReturnInTry()
        {
            int i;
            try
            {
                return i = 1;
            }
            finally
            {
                i = 2;
                Console.WriteLine("\t将int结果改为2，finally执行完毕");
            }
        }

        static User TestUserReturnInTry()
        {
            User user = new User() { Name = "Mike", BirthDay = new DateTime(2010, 1, 1) };
            try
            {
                return user;
            }
            finally
            {
                user.Name = "Rose";
                user.BirthDay = new DateTime(2010, 2, 2);
                Console.WriteLine("\t将user.Name改为Rose");
            }
        }

        private static User TestUserReturnInTry2()
        {
            User user = new User() { Name = "Mike", BirthDay = new DateTime(2010, 1, 1) };
            try
            {
                return user;
            }
            finally
            {
                user.Name = "Rose";
                user.BirthDay = new DateTime(2010, 2, 2);
                user = null;
                Console.WriteLine("\t将user置为null");
            }
        }
    }
}