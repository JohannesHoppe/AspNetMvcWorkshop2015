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
    using FluentAssertions;
    using Machine.Specifications;
    [Subject(typeof(CustomerRepository))]
    public class When_getting_special_customer
    {
        static CustomerRepository cr;
        static Customer result;

        private Establish context = () =>
        {
            //Arrange DB
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            DataContext db = new DataContext(connection);

            Customer cust1 = new Customer { FirstName = "Florian", LastName = "Benger" };
            Customer cust2 = new Customer { FirstName = "Urs", LastName = "Murpf" };
            Customer cust3 = new Customer { FirstName = "Ralf", LastName = "Schuhmacher" };
            Customer cust4 = new Customer { FirstName = "Jogi", LastName = "Löw" };

            db.Customers.Add(cust1);
            db.Customers.Add(cust2);
            db.Customers.Add(cust3);
            db.Customers.Add(cust4);
            db.SaveChanges();

            //Arrange repository
            cr = new CustomerRepository(db);
        };

        private Because of = () => result = cr.GetCustomer(3);

        private It should_return_customer_with_id_3 = () => result.Id.Should().Be(3);
    }
}
