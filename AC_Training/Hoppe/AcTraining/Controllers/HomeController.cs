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
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(model: "Text");
        }

        public ActionResult Grid()
        {
            return View();
        }

        public ActionResult Knockout()
        {
            return View();
        }
    }
}
