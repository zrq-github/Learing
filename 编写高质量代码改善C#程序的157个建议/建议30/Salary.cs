using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建议30
{
    // IComparable:比较当前对象和同一类型的另一对象
    class Salary : IComparable<Salary>
    {
        public string Name { get; set; }
        public int BaseSalary { get; set; }
        public int Bonus { get; set; }
        public Price Price { get; set; }
        #region IComparable成员

        public int CompareTo(Salary other)
        {
            return BaseSalary.CompareTo(other.BaseSalary);
        }
        #endregion
    }
}
