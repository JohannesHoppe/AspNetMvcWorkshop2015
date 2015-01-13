using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcTrainingTests
{
    using FluentAssertions;
    using Machine.Specifications;

    public class TestSetup
    {
        public static int value1;
        public static int value2;
        public static int result;

        Establish context = () =>
        {
            value1 = 1;   // hole Produkt
            value2 = 4;
        };

    }


    [Subject("DaxDelister")]
    public class When_doing_another_simple_test : TestSetup
    {
        Because of = () => result = value1 + value2;    // hier datum erreicht

        It should_be_deleted_automatically = () => result.Should().Be(5);
    }
}
