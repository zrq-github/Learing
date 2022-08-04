using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 建议66_WIn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Trace.WriteLine($"执行{nameof(CurrentDomain_UnhandledException)},{e.ToString()}");
        }

        private void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.Exception;
                string errorMsg = "WPF窗体线程异常:\n\n";
                MessageBox.Show(errorMsg + ex.Message + Environment.NewLine + ex.StackTrace);
                Trace.WriteLine(errorMsg + ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch
            {
                try
                {
                    MessageBox.Show("不可恢复的WPF窗体线程异常，应用程序将退出！");
                }
                finally
                {
                    Application.Current.Shutdown();
                }
            }
            e.Handled = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // 多线程退出
            Thread t = new Thread((ThreadStart)delegate
            {
                try
                {
                    throw new Exception("多线程异常");
                }
                catch (Exception error)
                {
                    Trace.WriteLine("工作线程异常：" + error.Message + Environment.NewLine + error.StackTrace);
                }
            });
            t.Start();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // 多线程退出
            Thread t = new Thread((ThreadStart)delegate
            {
                throw new Exception("多线程异常");
            });
            t.Start();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread((ThreadStart)delegate
            {
                try
                {
                    throw new Exception("非窗体线程异常, 线程传递给主线程");
                }
                catch (Exception ex)
                {
                    this.Dispatcher.BeginInvoke((Action)delegate
                    {
                        throw ex;
                    });
                }
            });
            t.Start();
        }
    }
}
