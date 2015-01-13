namespace AcTrainingTests
{
    using FluentAssertions;
    using Machine.Specifications;
    [Subject("Test")]
    public class When_doing_a_simple_test
    {
        static int value1;
        static int value2;
        static int result1;
        static int result2;
        
        private Establish context = () =>
        {
            value1 = 1;
            value2 = 2;
        };
        
        //Because of = () => result = value1 + value2;

        private Because of = () =>
        {
            result1 = value1 + value2;
            result2 = value1 - value2;
        };

        It should_have_the_expected_result = () => result1.Should().Be(3);

        It should_have_the_expected_result_negative = () => result2.Should().BeLessThan(0);
    }
}