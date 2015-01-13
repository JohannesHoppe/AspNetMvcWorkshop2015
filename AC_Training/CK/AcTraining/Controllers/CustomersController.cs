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
        private readonly ICustomerRepository _custRepos;

        public CustomersController(ICustomerRepository custRepos)
        {
            this._custRepos = custRepos;
        }      

        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return _custRepos.GetCustomers();
        }

        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
           Customer customer =  _custRepos.GetCustomer(id);
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

            try
            {
                int result = _custRepos.UpdateCustomer(id, customer);
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
                if (_custRepos.CustomerExists(id))
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

            if (_custRepos.CreateCustomer(customer) == 1)
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
            Customer customer = _custRepos.DeleteCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        /*--
        private bool CustomerExists(int id)
        {
            return _custRepos.Cust;
        }
        --*/
    }
}