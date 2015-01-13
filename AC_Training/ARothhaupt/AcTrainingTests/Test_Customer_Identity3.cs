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
    [Subject(typeof (CustomerRepository))]
    public class Test_Customer_Identity3
    {
        private static CustomerRepository repository;
        private static int result;

        private Establish context = () =>
        {
            //  Arranage DB --
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            DataContext context = new DataContext(connection);

            Customer customer1 = new Customer {FirstName = "Test1"};
            Customer customer2 = new Customer {FirstName = "Test2"};
            Customer customer3 = new Customer {FirstName = "Test3"};

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.SaveChanges();

            //  Arranage respository--
            repository = new CustomerRepository(context);

        };


        private Because of = () => result = repository.GetCustomer(3).Id;

        private It should_return_customers_with_Id_3 = () => result.Should().Be(3);
    }
}