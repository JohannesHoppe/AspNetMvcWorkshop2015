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
        private  readonly ICustomerRepository rep;

        public HomeController(ICustomerRepository rep)
        {
            this.rep = rep;
            //this.rep.CreateCustomer(new Customer {FirstName = DateTime.Now.ToLongTimeString()});

        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            string textString = "Das ist der Footer";
            return View(model: textString);
        }

        public ActionResult Test()
        {
            var customer = rep.GetCustomer(1);
            return View(customer);
        }
    }
}
