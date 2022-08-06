using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 建议71
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 线程测试
        /// </summary>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(() =>
            {
                var request = HttpWebRequest.Create("http://www.cnblogs.com/luminji");
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {
                    var content = reader.ReadLine();
                    this.Dispatcher.BeginInvoke(() =>
                    {
                        this.textBoxPage.Text = $"线程调用{content}";
                    });
                }
            });
            t.Start();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            var request = HttpWebRequest.Create("http://www.sina.com.cn");
            request.BeginGetResponse(this.AsyncCallbackImpl, request);
        }
        public void AsyncCallbackImpl(IAsyncResult ar)
        {
            WebRequest request = ar.AsyncState as WebRequest;
            var response = request.EndGetResponse(ar);
            var stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                var content = reader.ReadLine();
                //textBoxPage.Text = content;
                this.textBoxPage.Dispatcher.BeginInvoke(() =>
                {
                    this.textBoxPage.Text = content;
                });
            }
        }
    }
}
