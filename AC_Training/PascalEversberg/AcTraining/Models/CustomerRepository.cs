using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
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

        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        public Customer GetCustomer(int index)
        {
            return db.Customers.Find(index);
        }

        public int UpdateCustomer(int index, Customer cust)
        {

            if (index != cust.Id)
            {
                return -1;
            }

            db.Entry(cust).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(index))
                {
                    return -2;
                }
                throw;
            }

            return 1;
        }

        /*public Customer CreateCustomer(Customer cust)
        {
            Customer newCustomer;
            try
            {
                newCustomer = db.Customers.Add(cust);
                db.SaveChanges();
                return newCustomer;
            }
            catch(Exception)
            {
                return null;
            }
            
        }*/

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public int CreateCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();

            return 1;
        }

        public Customer DeleteCustomer(int index)
        {
            Customer cust = db.Customers.Find(index);

            if (cust == null)
            {
                return null;
            }

            db.Customers.Remove(cust);
            db.SaveChanges();
            return cust;
        }

        public bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }

    }
}