using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
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

        // GET: SELECT ALL
        public IQueryable<Customer> GetCustomers()
        {
            //return db.Customers;
            return db.Customers.ToList().AsQueryable();
        }

        // GET: SELECT WHERE ID
        public Customer GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            return customer;
        }

        // PUT: UPDATE
        public bool UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return false;
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
                    return false;
                }
            }

            return true;
        }

        // POST: INSERT
        public bool InsertCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return true;
        }

        // DELETE
        public bool DeleteCustomer(int id, out Customer deletedCustomer)
        {
            deletedCustomer = null;
            
            Customer customerToDelete = db.Customers.Find(id);
            if (customerToDelete == null)
            {
                return false;
            }
            
            deletedCustomer = customerToDelete;
            
            db.Customers.Remove(customerToDelete);
            db.SaveChanges();

            return true;
        }

        public bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}