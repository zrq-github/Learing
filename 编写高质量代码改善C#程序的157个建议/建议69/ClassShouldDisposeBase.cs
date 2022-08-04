using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建议69
{
    class ClassShouldDisposeBase : IDisposable
    {
        string _methodName;
        public ClassShouldDisposeBase(string methodName)
        {
            _methodName = methodName;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("在方法：" + _methodName + "中被释放！");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //执行基本的清理代码
            }
        }

        ~ClassShouldDisposeBase()
        {
            this.Dispose(false);
        }
    }
}
