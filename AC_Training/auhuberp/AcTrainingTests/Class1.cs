using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Machine.Specifications;

namespace AcTrainingTests
{

	public class TestSetup 
	{
		public static int value1;
		public static int value2;
		public static int result;

		private Establish context = () =>
		{
			value1 = 1;
			value2 = 2;
		};

	}

	[Subject("My_First_Test")]
	public class When_doing_a_simple_test : TestSetup
	{

		Because of = () => result = value1 + value2;

		It should_have_the_expected_result = () => result.Should().Be(3);
	}
}
