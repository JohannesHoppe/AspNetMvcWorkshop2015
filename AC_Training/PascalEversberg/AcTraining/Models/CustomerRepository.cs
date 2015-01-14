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
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IQueryable<Customer> GetCustomers()
        {
            //return _dataContext.Customers;
            return _dataContext.Customers.ToList().AsQueryable(); //nie in echt machen!
            //ToList().AsQueryable() => passiert im Arbeitsspeicher => bei vielen Datensätzen schlecht
        }

        public Customer GetCustomer(int index)
        {
            return _dataContext.Customers.Find(index);
        }

        public int UpdateCustomer(int index, Customer cust)
        {

            if (index != cust.Id)
            {
                return -1;
            }

            _dataContext.Entry(cust).State = EntityState.Modified;

            try
            {
                _dataContext.SaveChanges();
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
                newCustomer = _dataContext.Customers.Add(cust);
                _dataContext.SaveChanges();
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
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();

            return 1;
        }

        public Customer DeleteCustomer(int index)
        {
            Customer cust = _dataContext.Customers.Find(index);

            if (cust == null)
            {
                return null;
            }

            _dataContext.Customers.Remove(cust);
            _dataContext.SaveChanges();
            return cust;
        }

        public bool CustomerExists(int id)
        {
            return _dataContext.Customers.Count(e => e.Id == id) > 0;
        }

    }
}