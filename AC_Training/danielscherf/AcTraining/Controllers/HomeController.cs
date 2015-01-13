using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcTraining.Models;
using ModelBinderAttribute = System.Web.Http.ModelBinding.ModelBinderAttribute;

namespace AcTraining.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository _repository;

        public HomeController(ICustomerRepository repository)
        {
            _repository = repository;
            _repository.Insert(new Customer {FirstName = "Daniel", LastName = "Scherf", Mail = DateTime.Now.ToShortTimeString()});
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(model: "footer test");
        }

        public ActionResult Test()
        {
            var customer = _repository.GetCustomer(1);
            return View(customer);
        }
    }
}
