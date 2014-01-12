using System;
using Machine.Specifications;

namespace Extensions2.UnitTests
{
    public abstract class RewindDateTimeBase
    {
        protected static DayOfWeek RewindParameter;
        protected static int DaysInAWeek = 7;

        private Because of = () =>
                                 {
                                     Result = SourceDate.RewindToPrevious(RewindParameter);
                                 };

        protected static DateTime Result;
        protected static DateTime SourceDate;
        private It result_should_have_desired_day_of_week = () => Result.DayOfWeek.ShouldEqual(RewindParameter);
    }
}