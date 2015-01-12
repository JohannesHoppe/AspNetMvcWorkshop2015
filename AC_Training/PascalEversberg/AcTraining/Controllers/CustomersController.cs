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
        private readonly CustomerRepository rep;

        public CustomersController(CustomerRepository rep)
        {
            this.rep = rep;
        }      

        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return rep.GetCustomers();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = rep.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
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

            if (id != customer.Id)
            {
                return BadRequest();
            }

            rep.UpdateCustomer(id, customer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            var newCustomer = rep.CreateCustomer(customer);
            if (newCustomer == null)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("DefaultApi", new { id = newCustomer.Id }, newCustomer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer cust = rep.DeleteCustomer(id);

            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }

    }
}