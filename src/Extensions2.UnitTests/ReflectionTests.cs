using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Extensions2.UnitTests
{
    public class ReflectionFixtureBase
    {
        private Because of = () =>
                                 {
                                     Result = ClosedType.IsClosedTypeOf(OpenGenericType);
                                 };

        protected static bool Result;
        protected static Type ClosedType;
        protected static Type OpenGenericType;
    }

    [Subject("Reflection tests, interface to interface")]
    public class When_generic_interface_has_one_type_parameter : ReflectionFixtureBase
    {
        private Establish context = () =>
                                        {
                                            ClosedType = typeof (IEnumerable<int>);
                                            OpenGenericType = typeof (IEnumerable<>);
                                        };

        private It the_result_should_be_positive = () => Result.ShouldBeTrue();
    }

    [Subject("Reflection tests, interface to interface")]
    public class When_generic_interface_has_two_type_parameters : ReflectionFixtureBase
    {
        private Establish context = () =>
        {
            ClosedType = typeof(IDictionary<string, int>);
            OpenGenericType = typeof(IDictionary<,>);
        };

        private It the_result_should_be_positive = () => Result.ShouldBeTrue();
    }

    public class When_generic_class_has_one_parameter : ReflectionFixtureBase
    {
        private Establish context = () =>
        {
            ClosedType = typeof(List<int>);
            OpenGenericType = typeof(List<>);
        };

        private It the_result_should_be_positive = () => Result.ShouldBeTrue();
    }

    public class When_generic_interface_closes_generic_class: ReflectionFixtureBase
    {
        private Establish context = () =>
                                        {
                                            ClosedType = typeof (Dictionary<string, int>);
                                            OpenGenericType = typeof (IDictionary<,>);
                                        };

        private It the_result_should_be_positive = () => Result.ShouldBeTrue();
    }
}
