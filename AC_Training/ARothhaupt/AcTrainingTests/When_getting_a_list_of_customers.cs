﻿using System;
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
    public class When_getting_a_list_of_customers
    {
        private static CustomerRepository repository;
        private static IQueryable<Customer> result;

        private Establish context = () =>
        {
            //  Arranage DB --
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            DataContext context = new DataContext(connection);

            Customer customer1 = new Customer {FirstName = "Test1"};
            Customer customer2 = new Customer {FirstName = "Test2"};

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.SaveChanges();

            //  Arranage respository--
            repository = new CustomerRepository(context);

        };


        Because of = () => result = repository.GetCustomers();

        It should_return_all_customers_without_any_filtering = () =>
            result.Should().HaveCount(2);
    }
}
