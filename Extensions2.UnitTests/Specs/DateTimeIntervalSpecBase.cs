using System;
using Machine.Specifications;

namespace Extensions2.UnitTests.Specs
{
    public class DateTimeIntervalSpecBase
    {
        protected static DateTime Left;
        protected static DateTime Right;
        protected static DateDifference Result;

        private Because of = () =>
                                 {
                                     Result = Left.DayDifferenceWith(Right);
                                 };

        protected const int AmountOfMonthsInAYear = 12;
    }
}