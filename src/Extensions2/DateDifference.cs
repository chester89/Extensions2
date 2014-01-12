using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions2
{
    public struct DateDifference
    {
        public int Days { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }

        public static DateDifference Create(int days, int months = 0, int years = 0)
        {
            return new DateDifference
                       {
                           Days = days,
                           Months = months,
                           Years = years
                       };
        }
    }
}
