using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace 建议53
{
    class SimpleClass
    {
        string m_text;
        public SimpleClass(string text)
        {
            m_text = text;
        }
        ~SimpleClass()
        {
            MessageBox.Show(string.Format("SimpleClass Disposed,tag:{0}", m_text));
        }
    }
}
