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
    public class When_requesting_an_existing_customer
    {
        static CustomersController controller;
        static IHttpActionResult result;

        Establish context = () =>
        {
            // Einsatz des Mocking-Frameworks NSubstitute
            ICustomerRepository repository = Substitute.For<ICustomerRepository>(); // => CustomersController ist in diesem Test die einzige Unbekannte
            repository.GetCustomer(Arg.Any<int>()).Returns(new Customer ()); //Arg.Any<int> => egal welche Zahl, es wird immer ein Customer zurückgegeben

            controller = new CustomersController(repository);
        };

        Because of = () => result = controller.GetCustomer(99999);

        It should_respond_with_status_code_ok =
            () => result.Should().BeOfType<OkNegotiatedContentResult<Customer>>();
    }

    [Subject(typeof(CustomersController))]
    public class When_requesting_a_non_existing_customer
    {
        static CustomersController controller;
        static IHttpActionResult result;

        Establish context = () =>
        {
            ICustomerRepository repository = Substitute.For<ICustomerRepository>();
            Customer c = null;
            repository.GetCustomer(Arg.Any<int>()).Returns(c);
            controller = new CustomersController(repository);
        };

        Because of = () => result = controller.GetCustomer(99999);

        private It should_respond_with_status_code_not_found =
            () => result.Should().BeOfType<NotFoundResult>();
    }
}
