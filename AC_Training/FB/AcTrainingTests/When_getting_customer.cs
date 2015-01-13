using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AcTraining.Controllers;
using AcTraining.Models;
using NSubstitute;

namespace AcTrainingTests
{
    using FluentAssertions;
    using Machine.Specifications;
    [Subject(typeof(CustomerRepository))]
    public class When_getting_existing_customer
    {
        static CustomersController cc;
        static IHttpActionResult result;

        Establish context = () =>
        {
            ICustomerRepository cr = Substitute.For<ICustomerRepository>();
            cr.GetCustomer(Arg.Any<int>()).Returns(new Customer());
            cc = new CustomersController(cr);
        };

        Because of = () => result = cc.GetCustomer(1);

        It should_respond_with_status_code_ok =
            () => result.Should().BeOfType<OkNegotiatedContentResult<Customer>>();
    }

    public class When_getting_non_existing_customer
    {
        static CustomersController cc;
        static IHttpActionResult result;

        Establish context = () =>
        {
            ICustomerRepository cr = Substitute.For<ICustomerRepository>();
            Customer c = null;
            cr.GetCustomer(Arg.Any<int>()).Returns(c);
            cc = new CustomersController(cr);
        };

        Because of = () => result = cc.GetCustomer(1);

        It should_respond_with_status_code_not_found =
            () => result.Should().BeOfType<NotFoundResult>();
    }
}
