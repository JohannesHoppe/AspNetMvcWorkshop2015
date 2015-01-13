using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AcTraining.Models;
using FluentAssertions;
using Machine.Specifications;
using NMemory.Linq.Helpers;

namespace AcTrainingTests
{

    /*--
    public class SetupDatabase( int amountOfUser)
    {
        static CustomerRepository repository;

        
        return () =>
        {
        
        DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
        DataContext context = new DataContext(connection);

        foreach (int i=1; i<=amountOfUser; i++)
            {
                Customer c = new Customer {FirstName = ("First" + i.ToString()) };
                context.Customers.Add(c);
                
            }
            context.SaveChanges();

            repository = new CustomerRepository(context);
        };
    }
    
    [Subject(typeof(CustomerRepository))]
    public class When_getting_a_list_of_customers
    {
        private static IQueryable<Customer> result;

        private Establish context = SetupDatabase(2); 
        Because of = () => result = repository.GetCustomers();
        It should_return_Only_Two_pieces_customers = () => result.Should().HaveCount(2);

    }

    public class When_getting_id3_then_customer3_expected
    {
        static CustomerRepository repository;
        static Customer result;
        static Customer c3 = new Customer { FirstName = "First3" };

        private Establish context = () =>
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            DataContext context = new DataContext(connection);

            Customer c1 = new Customer {FirstName = "First0"};
            Customer c2 = new Customer {FirstName = "First2"};

            context.Customers.Add(c1);
            context.Customers.Add(c2);
            context.Customers.Add(c3);
            context.SaveChanges();

            repository = new CustomerRepository(context);

        };

        Because of = () => result = repository.GetCustomer(3);
        private It should_return_Only_customer3 = () => result.Should().Be(c3);

    }
    --*/
}
