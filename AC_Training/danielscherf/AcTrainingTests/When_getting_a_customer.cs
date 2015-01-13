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
    [Subject(typeof(CustomersController))]
    public class When_getting_a_customer
    {
        static CustomersController controller;

        private Establish context = () =>
        {
            //Moq


            ICustomerRepository repository = null;
            controller = new CustomersController(repository);
        };
    }
}
