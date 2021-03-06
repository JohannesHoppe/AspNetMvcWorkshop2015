﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.ModelBinding;

namespace AcTraining.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Customer GetCustomer(int id)
        {
            return _dataContext.Customers.Find(id);;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _dataContext.Customers;
        }

        public void UpdateCustomer(Customer pCustomer)
        {
            _dataContext.Entry(pCustomer).State = EntityState.Modified;

            try
            {
                //Customer customer = _dataContext.Customers.Find(Customer.id);
                _dataContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }
        }

        public Customer DeleteCustomer(int id)
        {
            Customer customer = _dataContext.Customers.Find(id);
            
            _dataContext.Customers.Remove(customer);
            _dataContext.SaveChanges();

            return customer;
        }

        public CustomerState.State CreateCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();

            return CustomerState.State.Ok;
        }

        public bool CustomerExists(int id)
        {
            return _dataContext.Customers.Count(e => e.Id == id) > 0;
        }
    }

    public static class CustomerState
    {
        public enum State {NotFound, Ok}
    }
}