using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建议30
{
    //IComparer:定义类型为比较两个对象而实现的方法。
    internal class BonusComparer : IComparer<Salary>
    {
        public int Compare(Salary x, Salary y)
        {
            return x.Bonus.CompareTo(y.Bonus);
        }
    }
}
