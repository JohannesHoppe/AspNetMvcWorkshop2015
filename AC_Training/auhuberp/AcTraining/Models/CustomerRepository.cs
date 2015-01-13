using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace AcTraining.Models
{
	public class CustomerRepository : ICustomerRepository
	{

		private readonly DataContext _db;

		public CustomerRepository(DataContext data)
		{
			this._db = data;
		}

		public DbSet<Customer> GetCustomers()
		{
			return _db.Customers;
		}

		public Customer GetCustomer(int id)
		{
			//Customer customer = db.Customers.Find(id);
			return _db.Customers.Find(id);
			
		}

		public enum UpdateRetVals
		{
			Ok = 0,
			BadRequest = 1,
			NotFound = 2
		}

		public UpdateRetVals UpdateCustomer(int id, Customer customer)
		{
			if (id != customer.Id)
			{
				return UpdateRetVals.BadRequest;
			}

			if (!_db.Customers.Any(co => co.Id == customer.Id))
				return UpdateRetVals.BadRequest;

			_db.Entry(customer).State = EntityState.Modified;

			try
			{
				_db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CustomerExists(customer.Id))
				{
					return UpdateRetVals.NotFound;
				}
				throw;
			}
			return  UpdateRetVals.Ok;
			//return StatusCode(HttpStatusCode.NoContent);
		}

		public void CreateCustomer(Customer customer)
		{
			_db.Customers.Add(customer);
			_db.SaveChanges();

			//return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
			return;
		}

		public bool DeleteCustomer(int id, out Customer customer)
		{
			customer = _db.Customers.Find(id);
			if (customer == null)
			{
				return false;
			}

			_db.Customers.Remove(customer);
			_db.SaveChanges();

			return true;
		}

		private bool CustomerExists(int id)
		{
			return _db.Customers.Count(e => e.Id == id) > 0;
		}


	}
}