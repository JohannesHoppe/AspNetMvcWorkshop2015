using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace AcTraining.Models
{
    public class CustomerRepository
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

        public bool UpdateCustomer(int index, Customer cust)
        {
            db.Entry(cust).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(index))
                {
                    return false;
                }
                throw;
            }
        }

        public Customer CreateCustomer(Customer cust)
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
            
        }

        public Customer DeleteCustomer(int index)
        {
            Customer cust = db.Customers.Find(index);
            try
            {
                db.Customers.Remove(cust);
                db.SaveChanges();
                return cust;
            }
            catch (Exception)
            {
                return cust;
            }

        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }

    }
}