using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建议30
{
    internal class Price : IComparable<Price>, IComparer<Price>
    {
        public double Value { get; set; }

        public int Compare(Price x, Price y)
        {
            return x.CompareTo(y);
        }

        public int CompareTo(Price other)
        {
            return Value.CompareTo(other.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
