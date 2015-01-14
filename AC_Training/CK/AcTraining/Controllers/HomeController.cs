using System;
using System.Globalization;
using System.Web.Mvc;
using AcTraining.Models;

namespace AcTraining.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository rep;

        public HomeController(ICustomerRepository rep)
        {
            this.rep = rep;
            this.rep.CreateCustomer(new Customer {FirstName = ("Claus_" + DateTime.Now.ToString(CultureInfo.InvariantCulture)) });

        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            string myText = "Das ist mein Text";

            return View(model:myText);
        }

        public ActionResult Test()
        {
            var customer = rep.GetCustomer(1);

            ViewBag.Title = "Test Page";

            return View(customer);
        }
       
        public ActionResult Grid()
        {

            return View();
        }
    }
}
