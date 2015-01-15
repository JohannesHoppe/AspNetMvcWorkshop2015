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
    public class CustomersController : ODataController//ApiController
    {
        private readonly ICustomerRepository cr;

        public CustomersController(ICustomerRepository custRep)
        {
            this.cr = custRep;
        }      

        // GET: api/Customers
        [EnableQuery]
        public IQueryable<Customer> GetCustomers()
        {
            return cr.GetCustomers();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = cr.GetCustomer(id);
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

            bool retVal = cr.UpdateCustomer(id, customer);

            if (!cr.CustomerExists(id))
            {
                return NotFound();
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

            bool retVal = cr.InsertCustomer(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer deletedCustomer;
            
            if(!cr.DeleteCustomer(id, out deletedCustomer))
                return NotFound();

            return Ok(deletedCustomer);
        }
    }
}