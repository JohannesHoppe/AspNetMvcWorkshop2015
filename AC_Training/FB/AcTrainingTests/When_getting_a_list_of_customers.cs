using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcTraining.Models;

namespace AcTrainingTests
{
    using FluentAssertions;
    using Machine.Specifications;
    [Subject(typeof(CustomerRepository))]
    public class When_getting_a_list_of_customers
    {
        static CustomerRepository cr;
        static IQueryable<Customer> result;

        private Establish context = () =>
        {
            //Arrange DB
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            DataContext db = new DataContext(connection);

            Customer cust1 = new Customer { FirstName = "Florian", LastName = "Benger" };
            Customer cust2 = new Customer { FirstName = "Urs", LastName = "Murpf" };

            db.Customers.Add(cust1);
            db.Customers.Add(cust2);
            db.SaveChanges();

            //Arrange repository
            cr = new CustomerRepository(db);
        };

        Because of = () => result = cr.GetCustomers();

        It should_return_all_customers = () => result.Should().HaveCount(2);
    }
}