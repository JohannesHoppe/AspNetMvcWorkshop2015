using FluentAssertions;
using Machine.Specifications;

namespace AcTrainingTests
{
    [Subject("Test")]
    public class When_doing_a_simple_test
    {
        static int value1;
        static int value2;
        static int result;

        private Establish context = () =>
                                    {
                                        value1 = 1;
                                        value2 = 2;
                                    };

        Because of = () => result = value1 + value2;

        It should_have_the_expected_result = () => result.Should().Be(3);
    }
}
