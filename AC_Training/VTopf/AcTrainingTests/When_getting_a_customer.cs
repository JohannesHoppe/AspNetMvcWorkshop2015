using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcTraining.Controllers;
using AcTraining.Models;
using Machine.Specifications;

namespace AcTrainingTests
{
    [Subject(typeof(CustomerRepository))]
    public class When_getting_a_customer
    {
        private static CustomersController controller;

        private Establish context = () =>
        {
            //Moq
            //NSubstitute

            ICustomerRepository repository = null;

            controller = new CustomersController();
        };
    }
}
