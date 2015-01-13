
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;


namespace AcTraining.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext db;

        public CustomerRepository(DataContext db)
        {
            this.db = db;
        } 

        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);

            return (customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        // POST: api/Customers
        public void CreateCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public bool UpdateCustomer(int id, Customer customer)
        {

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return (true);
            }
            catch (DbUpdateConcurrencyException)
            {
                return (false);
            }
        }

        public bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }

       
    }
}