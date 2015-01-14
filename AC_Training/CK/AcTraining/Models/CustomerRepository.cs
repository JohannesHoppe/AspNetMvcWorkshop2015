using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace AcTraining.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext db;

        public CustomerRepository(DataContext db)
        {
            this.db = db;
        }      

        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            //--return db.Customers;
            return db.Customers.ToList().AsQueryable();
        }

        // GET: api/Customers/5
        public Customer GetCustomer(int id)
        {
            return db.Customers.Find(id);
        }

        // PUT: api/Customers/5
        public int UpdateCustomer(int id, Customer customer)
        {

            if (id != customer.Id)
            {
                return -1;
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return -2;
                }
                throw;
            }

            return 1;   //--StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public int CreateCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();

            return 1;
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public Customer DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return null;
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return customer;
        }

        public bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }

    }
}