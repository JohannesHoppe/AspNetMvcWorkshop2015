using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AcTraining.Models;

namespace AcTraining.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _rep;

        public CustomersController(ICustomerRepository rep)
        {
            this._rep = rep;
        }      

        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return _rep.GetCustomers();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _rep.GetCustomer(id);
            if (customer == null)
            {
                return NotFound(); // darf nicht aus dem Repository kommen
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                int result = _rep.UpdateCustomer(id, customer);
                if (result == -1)
                {
                    return BadRequest(ModelState);
                }

                if (result == -2)
                {
                    return BadRequest();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_rep.CustomerExists(id))
                {
                    return NotFound();
                }
                throw;
            }

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

            if (_rep.CreateCustomer(customer) == 1)
            {
                return CreatedAtRoute("DefaultApi", new {id = customer.Id}, customer);
            }
            else
            {
                return null;
            }
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer cust = _rep.DeleteCustomer(id);

            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }

    }
}