using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcTraining.Controllers;
using Machine.Specifications;

namespace AcTrainingTests
{
    [Subject(typeof(CustomersController))]
    public class When_getting_a_customer
    {
        static CustomersController controller;

        Establish context = () =>
        {
            // Mögliche Mocking-Frameworks: Moq, NSubstitute
            controller = new CustomersController();
        };
    }
}
