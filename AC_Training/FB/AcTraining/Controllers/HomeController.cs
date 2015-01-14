using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcTraining.Models;

namespace AcTraining.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository cr;

        public HomeController(ICustomerRepository p_cr)
        {
            cr = p_cr;
            //cr.InsertCustomer(new Customer {FirstName = "Urs", LastName = "Murpf", Mail=DateTime.Now.ToShortDateString()});
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            const string text = "Content of footer section: normally used for scripts";
            return View(model: text);
        }

        public ActionResult Test()
        {
            //ViewBag.Title = "Home Test Page";
            var customer = cr.GetCustomer(1);
            if (customer == null)
                customer = new Customer { FirstName = "Urs", LastName = "Murpf", Mail = DateTime.Now.ToShortDateString() };
            return View(customer);
        }
    }
}
