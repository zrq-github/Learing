namespace 建议64
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new
            UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            try
            {
                throw new Exception("主动捕获的异常");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }

            throw new Exception("未捕获的异常");
            Console.ReadKey();
        }

        static void CurrentDomain_UnhandledException(object sender,
        UnhandledExceptionEventArgs e)
        {
            Exception error = (Exception)e.ExceptionObject;
            Console.WriteLine("MyHandler caught:" + error.Message);
        }
    }
}