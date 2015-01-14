using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AcTraining.Controllers;
using AcTraining.Models;
using FluentAssertions;
using Machine.Specifications;
using NSubstitute;

namespace AcTrainingTests
{
				//public static Establish SetupDatabase(int amountOfCustomer = 2)
				//{
				//		return () =>
				//		{
				//				DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
				//				DataContext context = new DataContext(connection);

				//				for (int i = 1; i < amountOfCustomer + 1; i++)
				//				{
				//						context.Customers.Add(new Customer { FirstName = "Test" + i });
				//				}
				//				context.SaveChanges();

				//				repository = new CustomerRepository(context);
				//		};
				//} 

	[Subject(typeof(CustomersController))]
	class When_requesting_an_existing_customer
	{
		private static CustomersController controller;
		private static IHttpActionResult result;

		private Establish context = () =>
			{
				// Framework Moq
				// NSubstitue - über Nuget Packagemanager installieren
				ICustomerRepository repository = Substitute.For<ICustomerRepository>();
				Customer c = null;
				//repository.GetCustomer(4).Returns(new Customer { FirstName = "Kunde 4" });
				repository.GetCustomer(Arg.Any<int>()).Returns(c);
				controller = new CustomersController(repository);

			};

		Because of = () => result = controller.GetCustomer(9999);

		//It should_respond_with_status_code_ok =
		//	() => result.Should().BeOfType(OkNegotiatedContentResult<Customer>);

		It should_respond_with_status_not_found =
		() => result.Should().BeOfType<NotFoundResult>();
	}
}
