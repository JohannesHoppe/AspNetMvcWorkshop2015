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
    [Subject(typeof(CustomerRepository))]
    public class When_requesting_an_existing_customer
    {
        private static CustomersController controller;
        private static IHttpActionResult result;

        private Establish context = () =>
        {
            //Moq
            //NSubstitute
            ICustomerRepository repository = Substitute.For<ICustomerRepository>();

            repository.GetCustomer(Arg.Any<int>()).Returns(new Customer());
            //repository.GetCustomer(4).Returns(new Customer() {FirstName = "Test4"});

            controller = new CustomersController(repository);
        };

        private Because of = () => result = controller.GetCustomer(939393);

        private It should_respond_with_status_code_ok =
            () => result.Should().BeOfType<OkNegotiatedContentResult<Customer>>();
    }
}
