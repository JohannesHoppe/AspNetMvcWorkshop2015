namespace AcTrainingTests
{
    using FluentAssertions;
    using Machine.Specifications;

    [Subject("DaxDelister")]
    public class When_we_have_an_index_product
    {
        static int value1;
        static int value2;
        static int result;

        Establish context = () =>
        {
            value1 = 1;   // hole Produkt
            value2 = 2;
        };

        Because of = () => result = value1 + value2;    // hier datum erreicht

        It should_be_deleted_automatically = () => result.Should().Be(3);

        public It should_be_deleted_automatically2 = () => result.Should().Be(3);
    }
}
