using System;
using Machine.Specifications;

namespace Extensions2.UnitTests.Specs
{
    [Subject("Calculating difference between two dates")]
    public class When_dates_are_inside_one_month_of_the_same_year : DateTimeIntervalSpecBase
    {
        private Establish context = () =>
                                        {
                                            Left = new DateTime(2012, 2, 13);
                                            Right = new DateTime(2012, 2, 16);
                                        };

        private It should_equal_difference_in_days = () => Result.Days.ShouldEqual(Right.Day - Left.Day);
        private It should_not_consider_months_difference = () => Result.Months.ShouldEqual(Right.Month - Left.Month);
        private It should_not_consider_month_difference = () => Result.Years.ShouldEqual(Right.Year - Left.Year);
    }

    [Subject("Calculating difference between two dates")]
    public class When_dates_are_from_nearest_months_in_the_same_year: DateTimeIntervalSpecBase
    {
        private Establish context = () =>
                                        {
                                           Left = new DateTime(2012, 1, 30);
                                           Right = new DateTime(2012, 2, 1);
                                        };

        private It should_respect_different_months = () => Result.Days.ShouldEqual(2);
        private It should_not_consider_month_difference = () => Result.Months.ShouldEqual(Right.Month - Left.Month - 1);
        private It should_not_consider_year_difference = () => Result.Years.ShouldEqual(Right.Year - Left.Year);
    }

    [Subject("Calculating difference between two dates")]
    public class When_dates_are_from_distant_months_in_the_same_year: DateTimeIntervalSpecBase
    {
        private Establish context = () =>
        {
            Left = new DateTime(2011, 3, 26);
            Right = new DateTime(2011, 10, 14);
        };

        private It should_respect_different_months = () => Result.Days.ShouldEqual(Right.Day + DateTime.DaysInMonth(Left.Year, Left.Month) - Left.Day);
        private It should_consider_month_difference = () => Result.Months.ShouldEqual(6);
        private It should_not_consider_year_difference = () => Result.Years.ShouldEqual(Right.Year - Left.Year);
    }

    [Subject("Calculating difference between two dates")]
    public class When_dates_are_from_distant_months_with_days_overflow_in_the_same_year: DateTimeIntervalSpecBase
    {
        private Establish context = () =>
                                        {
                                            Left = new DateTime(2011, 3, 9);
                                            Right = new DateTime(2011, 10, 14);
                                        };

        private It should_respect_days_overflow = () => Result.Days.ShouldEqual(Right.Day - Left.Day);
        private It should_consider_month_difference_with_overflow = () => Result.Months.ShouldEqual(7);
        private It should_not_consider_year_difference = () => Result.Years.ShouldEqual(Right.Year - Left.Year);
    }

    [Subject("Calculating difference between two dates")]
    public class When_dates_are_from_different_years_and_month_underflows : DateTimeIntervalSpecBase
    {
        private Establish context = () =>
                                        {
                                            Left = new DateTime(2011, 3, 26);
                                            Right = new DateTime(2012, 1, 17);
                                        };

        private It should_consider_days_underflow = () => Result.Days.ShouldEqual(Right.Day + DateTime.DaysInMonth(Left.Year, Left.Month) - Left.Day);
        private It should_consider_month_difference = () => Result.Months.ShouldEqual(AmountOfMonthsInAYear - Left.Month + Right.Month - 1);
        private It should_not_consider_years_difference = () => Result.Years.ShouldEqual(0);
    }

    [Subject("Calculating difference between two days")]
    public class When_dates_are_from_different_years: DateTimeIntervalSpecBase
    {
        private Establish context = () =>
                                        {
                                            Left = new DateTime(2011, 2, 1);
                                            Right = new DateTime(2012, 2, 10);
                                        };

        It should_respect_days_inside_one_month = () => Result.Days.ShouldEqual(Right.Day - Left.Day);
        private It should_respect_month_equality = () => Result.Months.ShouldEqual(Right.Month - Left.Month);
        private It should_consider_year_difference = () => Result.Years.ShouldEqual(1);
    }
}
