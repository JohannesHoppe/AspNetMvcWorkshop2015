using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using AcTraining.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;

namespace AcTraining.Controllers
{
    /*
    // WepApiConfig.cs
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Customer>("Customers2");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class Customers2Controller : ODataController
    {
        private readonly DataContext db;

        public Customers2Controller(DataContext db)
        {
            this.db = db;
        }     

        // GET: odata/Customers2
        [EnableQuery]
        public IQueryable<Customer> GetCustomers2()
        {
            return db.Customers;
        }

        // GET: odata/Customers2(5)
        [EnableQuery]
        public SingleResult<Customer> GetCustomer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Customers.Where(customer => customer.Id == key));
        }

        // PUT: odata/Customers2(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Customer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = db.Customers.Find(key);
            if (customer == null)
            {
                return NotFound();
            }

            patch.Put(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(customer);
        }

        // POST: odata/Customers2
        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return Created(customer);
        }

        // PATCH: odata/Customers2(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Customer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = db.Customers.Find(key);
            if (customer == null)
            {
                return NotFound();
            }

            patch.Patch(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(customer);
        }

        // DELETE: odata/Customers2(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Customer customer = db.Customers.Find(key);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            var context = GlobalHost.ConnectionManager.GetHubContext<CustomerHub>();
            context.Clients.All.customerDeleted(key);

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool CustomerExists(int key)
        {
            return db.Customers.Count(e => e.Id == key) > 0;
        }
    }
}
