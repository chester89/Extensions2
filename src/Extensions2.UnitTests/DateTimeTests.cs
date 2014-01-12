using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Extensions2.UnitTests
{
    [Subject("DateTime rewinding simple case")]
    public class When_rewinding_back_inside_one_month_and_one_week : RewindDateTimeBase
    {
        private Establish context = () =>
        {
            SourceDate = new DateTime(2012, 04, 20);
            RewindParameter = DayOfWeek.Wednesday;
        };

        private It should_rewind_to_correct_day = () => Result.Day.ShouldEqual(SourceDate.Day - (int)SourceDate.DayOfWeek + (int)RewindParameter);
        private It should_rewind_to_correct_month = () => Result.Month.ShouldEqual(SourceDate.Month);
        private It should_rewind_to_correct_year = () => Result.Year.ShouldEqual(SourceDate.Year);

        private It difference_in_days_should_be_no_more_than_week_length =
            () => (SourceDate.Day - Result.Day).ShouldBeLessThanOrEqualTo(DaysInAWeek);
    }

    [Subject("DateTime rewinding simple case")]
    public class When_rewinding_back_inside_one_month_and_different_weeks : RewindDateTimeBase
    {
        private Establish context = () =>
        {
            SourceDate = new DateTime(2012, 04, 20);
            RewindParameter = DayOfWeek.Saturday;
        };

        //private It should_rewind_to_correct_day = () => Result.Day.ShouldEqual(14);
        private It should_rewind_to_correct_month = () => Result.Month.ShouldEqual(SourceDate.Month);
        private It should_rewind_to_correct_year = () => Result.Year.ShouldEqual(SourceDate.Year);
        private It difference_in_days_should_be_no_more_than_week_length =
            () => (SourceDate.Day - Result.Day).ShouldBeLessThanOrEqualTo(DaysInAWeek);
    }

    [Subject("DateTime rewinding")]
    public class When_rewinding_back_on_month_edge: RewindDateTimeBase
    {
        private Establish context = () =>
                                        {
                                            SourceDate = new DateTime(2012, 04, 03);
                                            RewindParameter = DayOfWeek.Friday;
                                        };
        //It should_rewind_to_correct_day = () => Result.Day.ShouldEqual(DateTime.DaysInMonth(SourceDate.Year, SourceDate.Month - 1) - (SourceDate.Day - (int)SourceDate.DayOfWeek + (int)RewindParameter));
        private It should_rewind_to_correct_month = () => Result.Month.ShouldEqual(SourceDate.Month - 1);
        private It should_rewind_to_correct_year = () => Result.Year.ShouldEqual(SourceDate.Year);
    }
}
