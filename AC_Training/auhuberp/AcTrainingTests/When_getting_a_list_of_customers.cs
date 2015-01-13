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
	public class When_getting_a_list_of_customers
	{
		// LambdaExpressions können nur in statische properties schreiben
		static CustomerRepository repository;
		private static IQueryable<Customer> result;

		private Establish context = () =>
			{
				// Arrange Database
				DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
				DataContext context = new DataContext(connection);

				Customer customer1 = new Customer() { FirstName = "Test1" };
				Customer customer2 = new Customer() { FirstName = "Test2" };

				context.Customers.Add(customer1);
				context.Customers.Add(customer2);
				context.SaveChanges();

				// Arrange repository
				repository = new CustomerRepository(context);



			};

		// Act
		private Because of = () => result = repository.GetCustomers();

		// Assertion
		private It should_return_all_customers_without_any_filtering = () => result.Should().HaveCount(2);
		//private It should_return_all_customers_without_any_filtering2 = () => result.Count().Should().Be(2);

	}
}
