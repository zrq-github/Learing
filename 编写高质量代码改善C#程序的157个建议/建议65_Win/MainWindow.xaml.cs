using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace 建议65_Win
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            this.Dispatcher.UnhandledException += new DispatcherUnhandledExceptionEventHandler(Application_DispatcherUnhandledException);
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.ExceptionObject as Exception;
                string errorMsg = "非WPF窗体线程异常:\n\n";
                MessageBox.Show(errorMsg + ex.Message + Environment.NewLine + ex.StackTrace);
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
        }
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.Exception;
                string errorMsg = "WPF窗体线程异常:\n\n";
                MessageBox.Show(errorMsg + ex.Message + Environment.NewLine + ex.StackTrace);
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
            throw new Exception("窗体线程异常");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread((ThreadStart)delegate
            {
                throw new Exception("非窗体线程异常");
            });
            t.Start();
        }
    }
}
