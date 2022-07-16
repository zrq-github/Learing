using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 建议46_显式释放资源
{
    public class SampleClass : IDisposable
    {
        private bool disposed = false;

        //演示创建一个托管资源
        private AnotherResource managedResource = new AnotherResource();

        //演示创建一个非托管资源
        private IntPtr nativeResource = Marshal.AllocHGlobal(100);
        ///＜summary＞
        ///必需的，防止程序员忘记了显式调用Dispose方法
        ///＜/summary＞
        ~SampleClass()
        {
            //必须为false
            Dispose(false);
        }

        ///＜summary＞
        ///不是必要的，提供一个Close方法仅仅是为了更符合其他语言（如C++）的规范
        ///＜/summary＞
        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            //  必须为true
            Dispose(true);
            //  通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
        }

        // 避免函数再次调用.
        public void SamplePublicMethod()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("SampleClass", "SampleClass is disposed");
            }
            //省略
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //清理托管资源
                if (managedResource != null)
                {
                    managedResource.Dispose();
                    managedResource = null;
                }
            }

            //清理非托管资源
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }
            //让类型知道自己已经被释放
            disposed = true;
        }
    }
}
