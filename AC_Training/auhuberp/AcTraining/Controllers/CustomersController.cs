using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using AcTraining.Models;

namespace AcTraining.Controllers
{
	public class CustomersController : ODataController
	{
		private readonly ICustomerRepository cr;

		public CustomersController(ICustomerRepository cr)
		{
			this.cr = cr;
		}

		// GET: api/Customers
		public IQueryable<Customer> GetCustomers()
		{
			return cr.GetCustomers();
		}

		// GET: api/Customers/5
		[ResponseType(typeof(Customer))]
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = cr.GetCustomer(id);
			if (customer == null)
				return NotFound();
			return Ok(customer);
		}

		// PUT: api/Customers/5
		[ResponseType(typeof(void))]
		public IHttpActionResult PutCustomer(int id, Customer customer)
		{
			if (!ModelState.IsValid)		// e.g. for data annotation [Required] bzw. [MaxLength] in Customer.cs
			{
				return BadRequest(ModelState);
			}

			var updRet = cr.UpdateCustomer(id, customer);

			if (updRet == CustomerRepository.UpdateRetVals.BadRequest)
				return BadRequest();
			else if (updRet == CustomerRepository.UpdateRetVals.NotFound)
				return NotFound();

			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/Customers
		[ResponseType(typeof(Customer))]
		public IHttpActionResult PostCustomer(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			cr.CreateCustomer(customer);

			return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
		}

		// DELETE: api/Customers/5
		[ResponseType(typeof(Customer))]
		public IHttpActionResult DeleteCustomer(int id)
		{
			Customer customer = null;
			if (cr.DeleteCustomer(id, out customer))
			{
				return NotFound();
			}
			else
			{
			return Ok(customer);			
			}
		}

	}
}