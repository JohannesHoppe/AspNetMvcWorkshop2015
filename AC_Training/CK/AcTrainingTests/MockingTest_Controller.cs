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
    [Subject(typeof (CustomersController))]
    public class When_getting_a_customer
    {
        private static CustomersController controller;
        private static IHttpActionResult result;

        private Establish context = () =>
        {
            ICustomerRepository repository = Substitute.For<ICustomerRepository>();
            repository.GetCustomer(Arg.Any<int>()).Returns(new Customer());

            controller = new CustomersController(repository);
        };

        Because of = () => result = controller.GetCustomer(1);

        It schould_responde_statuscode_ok =
            () => result.Should().BeOfType<OkNegotiatedContentResult<Customer>>();
    }

    [Subject(typeof(CustomersController))]
    public class When_requesting_a_non_customer
    {
        private static CustomersController controller;
        private static IHttpActionResult result;

        private Establish context = () =>
        {
            ICustomerRepository repository = Substitute.For<ICustomerRepository>();
            Customer c = null;
            repository.GetCustomer(Arg.Any<int>()).Returns(c);

            controller = new CustomersController(repository);
        };

        Because of = () => result = controller.GetCustomer(1);

        It schould_responde_statuscode_not_found=
            () => result.Should().BeOfType<NotFoundResult>();
    }
}
