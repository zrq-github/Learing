using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace 建议65_Win
{
    internal class Class1
    {
        public void AA()
        {
            Thread t = new Thread((ThreadStart)delegate
            {
                try
                {
                    throw new Exception("多线程异常");
                }
                catch (Exception error)
                {
                    MessageBox.Show("工作线程异常：" + error.Message + Environment.NewLine + error.StackTrace);
                }
            });
            t.Start();

        }
    }
}
