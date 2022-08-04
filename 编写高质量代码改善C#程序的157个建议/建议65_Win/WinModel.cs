using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建议65_Win
{
    public class WinModel : UIModelBase
    {
        private string propertyExcetion = "属性异常测试, set里面有异常, 动一下就抛异常";

        public string PropertyExcetion
        {
            get => propertyExcetion; 
            set
            {
                propertyExcetion = value;
                OnPropertyChanged();
            }
        }
    }
}
