using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using NMemory.Linq;

namespace AcTraining.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext _db;

        public CustomerRepository(DataContext db)
        {
            _db = db;
        }

        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return _db.Customers.ToList().AsQueryable();
        }

        // GET: api/Customers/5
        public Customer GetCustomer(int id)
        {
            return _db.Customers.Find(id);
        }

        public int Insert(Customer obj)
        {
            _db.Customers.Add(obj);
            return _db.SaveChanges();
        }

        public int Update(Customer obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public Customer Delete(int id)
        {
            Customer existing = _db.Customers.Find(id);
            if (existing == null)
                return null;
            else
            {
                Customer _cust = _db.Customers.Remove(existing);
                _db.SaveChanges();
                return _cust;
            }
        }

        public bool CustomerExists(int id)
        {
            return _db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}