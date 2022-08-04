namespace 建议69
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Method1();

            Method3();
        }

        static void Method1()
        {
            ClassShouldDisposeBase c = null;
            try
            {
                c = new ClassShouldDisposeBase("Method1");
                Method2();
            }
            finally
            {
                c.Dispose();
            }
        }

        static void Method2()
        {
            ClassShouldDisposeBase c = null;
            try
            {
                c = new ClassShouldDisposeBase("Method2");
            }
            finally
            {
                c.Dispose();
            }
        }


        static void Method3()
        {
            ClassShouldDisposeBase c = null;
            try
            {
                c = new ClassShouldDisposeBase("Method3");
                Method4();
            }
            catch
            {
                Console.WriteLine("在Method3中捕获了异常。");
            }
            finally
            {
                c.Dispose();
            }
        }

        static void Method4()
        {
            ClassShouldDisposeBase c = null;
            try
            {
                c = new ClassShouldDisposeBase("Method4");
                throw new Exception();
            }
            catch
            {
                Console.WriteLine("在Method4中捕获了异常。");
                throw;
            }
            finally
            {
                c.Dispose();
            }
        }
    }
}