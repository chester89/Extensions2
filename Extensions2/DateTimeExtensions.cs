using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions2
{
    public static class DateTimeExtensions
    {
        public const int AmountOfMonthsInAYear = 12;

        public static DateDifference DayDifferenceWith(this DateTime left, DateTime right)
        {
            int daysAmount = 0;
            if (left.Month == right.Month && left.Year == right.Year)
            {
                daysAmount = right.Day - left.Day;
                return DateDifference.Create(daysAmount);
            }
            var year = left.Year;
            daysAmount = DateTime.DaysInMonth(year, left.Month) - left.Day + right.Day;

            var monthAmount = 0;
            if (right.Month > left.Month)
            {
                monthAmount = right.Month - left.Month;
            }
            else
            {
                monthAmount = AmountOfMonthsInAYear + right.Month - left.Month;
                if (right.Day <= left.Day)
                {
                    monthAmount -= 1;
                }
            }
            int calculatedMonth = 0;
            if (right.Day > left.Day)
            {
                if (left.Month != right.Month)
                {
                    calculatedMonth = 1;
                }
                daysAmount -= DateTime.DaysInMonth(left.Year, left.Month);
            }
            
            //convert months to years if months overflow
            var years = 0;
            while (monthAmount >= AmountOfMonthsInAYear)
            {
                monthAmount -= AmountOfMonthsInAYear;
                years += 1;
            }

            //edge month is considered only when difference in month component between dates are more than 1
            int amountOfEdgeMonths = 0;
            if (monthAmount >= 1 && right.Month > left.Month)
            {
                amountOfEdgeMonths = 1;
            }

            return DateDifference.Create(daysAmount, monthAmount - amountOfEdgeMonths + calculatedMonth, years);
        }
    }
}
