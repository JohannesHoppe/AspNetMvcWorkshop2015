using System;
using System.Web.Mvc;
using AcTraining.Models;

namespace AcTraining.Controllers
{
    [RequestTimingFilter]
    public class HomeController : Controller
    {
        private readonly ICustomerRepository rep; 

        public HomeController(ICustomerRepository rep)
        {
            this.rep = rep;
            //this.rep.CreateCustomer(new Customer {FirstName = DateTime.Now.ToLongTimeString()});
        }
        

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(model: "Text");
        }

        public ActionResult Test()
        {
            var customer = rep.GetCustomer(1);

            return View(customer);
        }

        public string Test2()
        {
            return "<html><h1>Test</h1></html>";
        }
    }
}
