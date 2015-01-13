using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcTrainingTests
{
    using FluentAssertions;
    using Machine.Specifications;

    [Subject("Test")] //Definiert und markiert einen ausführbaren Taest
    public class When_doing_a_simple_test
    {
        static int value1;
        static int value2;
        static int result;

        private Establish context = () => // ARRANGE = Vorbereitung; keine Methode, sondern Lambda-Expression -> Wert
        {
            value1 = 1;
            value2 = 2;
        };

        Because of = () => result = value1 + value2; // ACT

        It should_have_the_expected_result = () => result.Should().Be(3); // ASSERTION; es kann auch mehrere geben
    }

}
