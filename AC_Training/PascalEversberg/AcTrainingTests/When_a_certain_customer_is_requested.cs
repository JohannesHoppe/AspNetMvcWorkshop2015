using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcTraining.Models;
using FluentAssertions;
using Machine.Specifications;

namespace AcTrainingTests
{
    [Subject(typeof(CustomerRepository))]
    class When_a_certain_customer_is_requested
    {
        static CustomerRepository repository;
        static Customer result;

        Establish context = () =>
        {
            // Arrange DB (i.e. DB erzeugen)
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            DataContext context = new DataContext(connection);

            //Kunden hinzufügen
            Customer customer1 = new Customer { FirstName = "Hans" }; //Default-Kostruktor wird aufgerufen und die angegebenen Properties gefüllt
            Customer customer2 = new Customer { FirstName = "Fritz" };
            Customer customer3 = new Customer { FirstName = "Herbert" };

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.SaveChanges();

            // Arrange repository
            repository = new CustomerRepository(context);
        };
        // Act
        Because of = () => result = repository.GetCustomer(3);

        private It should_return_the_customer_with_the_given_id = () =>
            result.Id.Should().Be(3);
    }
}
