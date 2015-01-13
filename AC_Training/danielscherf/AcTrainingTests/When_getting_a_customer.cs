using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AcTraining.Controllers;
using AcTraining.Models;
using FluentAssertions;
using Machine.Specifications;
using NSubstitute;

namespace AcTrainingTests
{
    [Subject(typeof(CustomersController))]
    public class When_getting_a_customer
    {
        static CustomersController controller;
        static IHttpActionResult result;

        private Establish context = () =>
        {
            ICustomerRepository repository = Substitute.For<ICustomerRepository>();
            repository.GetCustomer(Arg.Any<int>()).Returns(new Customer());
            controller = new CustomersController(repository);
        };

        Because of = () => result = controller.GetCustomer(99999);

        It should_responde_the_status_code_ok =
            () => result.Should().BeOfType<OkNegotiatedContentResult<Customer>>();
    }

    public class When_requesting_an_non_existing_customer
    {
        static CustomersController controller;
        static IHttpActionResult result;

        private Establish context = () =>
        {
            ICustomerRepository repository = Substitute.For<ICustomerRepository>();
            Customer c = null;
            repository.GetCustomer(Arg.Any<int>()).Returns(c);
            controller = new CustomersController(repository);
        };

        Because of = () => result = controller.GetCustomer(99999);

        It should_responde_the_status_code_ok =
            () => result.Should().BeOfType<NotFoundResult>();
    }
}
