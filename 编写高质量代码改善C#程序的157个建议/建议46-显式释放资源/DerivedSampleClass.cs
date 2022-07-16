using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 建议46_显式释放资源
{
    public class DerivedSampleClass : SampleClass
    {
        //子类的非托管资源
        private IntPtr derivedNativeResource = Marshal.AllocHGlobal(100);//子类的托管资源
        private AnotherResource derivedManagedResource = new AnotherResource();

        //定义自己的是否释放的标识变量
        private bool derivedDisposed = false;

        ///＜summary＞
        ///非密封类修饰用protected virtual
        ///密封类修饰用private
        ///＜/summary＞
        ///＜param name="disposing"＞＜/param＞
        protected virtual void Dispose(bool disposing)
        {
            if (derivedDisposed)
            {
                return;
            }

            if (disposing)
            {
                //清理托管资源
                if (derivedManagedResource != null)
                {
                    derivedManagedResource.Dispose();
                    derivedManagedResource = null;
                }
            }

            //清理非托管资源
            if (derivedNativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(derivedNativeResource);
                derivedNativeResource = IntPtr.Zero;
            }

            //调用父类的清理代码
            base.Dispose(disposing);

            //让类型知道自己已经被释放
            derivedDisposed = true;
        }
    }
}
