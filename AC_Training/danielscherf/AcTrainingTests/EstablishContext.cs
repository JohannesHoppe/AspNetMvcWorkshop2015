using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcTraining.Models;
using Machine.Specifications;

namespace AcTrainingTests
{
    public class EstablishContext
    {
        public static CustomerRepository repository;
        public static Establish CreateContext()
        {
    
            return () =>
            {
                // Arrange DB
                DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
                DataContext context = new DataContext(connection);
                Customer customer1 = new Customer {FirstName = "Test1"};
                Customer customer2 = new Customer {FirstName = "Test2"};
                Customer customer3 = new Customer {FirstName = "Test3"};

                context.Customers.Add(customer1);
                context.Customers.Add(customer2);
                context.Customers.Add(customer3);
                context.SaveChanges();

                // Arrange repository
                repository = new CustomerRepository(context);
            };
        }

    }


}
