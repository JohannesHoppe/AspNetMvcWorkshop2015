using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcTraining.Models;
using FluentAssertions;
using Machine.Specifications;

namespace AcTrainingTests
{

    [Subject(typeof(CustomerRepository))]
    public class Getting_exactly_customer_3 : EstablishContext
    {
        //private static CustomerRepository repository;
        private static Customer customer;

        private Establish context = () =>
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            DataContext context = new DataContext(connection);

            Customer customer1 = new Customer { FirstName = "Test1" };
            Customer customer2 = new Customer { FirstName = "Test2" };
            Customer customer3 = new Customer { FirstName = "Test3" };

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);

            context.SaveChanges();

            //Arrange repository
            repository = new CustomerRepository(context);
        };

        Because of = () => customer = repository.GetCustomer(3);

        private It should_return_customer_with_id_3 = () =>
            customer.FirstName.Should().Be("Test3");
    }
}
