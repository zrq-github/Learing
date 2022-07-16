using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace 建议53
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Method1();
            Method2();
        }

        private void Method2()
        {
            SimpleClass s = new SimpleClass("method2");
        }

        private void Method1()
        {
            SimpleClass s = new SimpleClass("method1");
            s = null;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}
