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
    [Subject(typeof(CustomerRepository))] //=> Gruppierung in der Ergebnisansicht
    public class When_getting_a_list_of_customers
    {
        // static muss sein, weil Lambda-Expressions nur in static-Variablen schreiben können
        static CustomerRepository repository;
        static IQueryable<Customer> result; 

        Establish context = () =>
        {
            // Arrange DB (i.e. DB erzeugen)
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient(); //DB wird bei Garbage Collection gelöscht
            DataContext context = new DataContext(connection);

            //Kunden hinzufügen
            Customer customer1 = new Customer {FirstName = "Hans"}; //Default-Kostruktor wird aufgerufen und die angegebenen Properties gefüllt
            Customer customer2 = new Customer {FirstName = "Fritz"};

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.SaveChanges();

            // Arrange repository
            repository = new CustomerRepository(context);
        };
        // Act
        Because of = () => result = repository.GetCustomers();

        It should_return_all_customers_without_filtering = () =>
            //Fluent Assertions -> Should(). liefert Auswahlliste
            result.Should().HaveCount(2); //Alternativ: result.Count().Should().Be(2);
    }
}
