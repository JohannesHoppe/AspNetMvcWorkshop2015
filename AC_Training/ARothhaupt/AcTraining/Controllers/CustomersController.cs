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
        //private readonly DataContext db;
        private readonly Models.CustomerRepository _custRep;

        public CustomersController(CustomerRepository customerRep)
        {
            _custRep = customerRep;
        }      

        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()    
        {
            return _custRep.GetCustomers();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _custRep.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = _custRep.GetCustomer(id);
            if (customer != null)
            {
                _custRep.DeleteCustomer(customer);
                return Ok(customer);
            }
            return NotFound();         
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _custRep.CreateCustomer(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (0 == customer.Id)
            {
                return BadRequest();
            }

           if (_custRep.UpdateCustomer(id, customer) != true)
               return NotFound();

           return Ok(customer);
            //return StatusCode(HttpStatusCode.NoContent);
        }


    }
}