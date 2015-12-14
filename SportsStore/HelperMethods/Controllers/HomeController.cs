using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Fruits = new[] {"Apple", "Orange", "Pear"};
            ViewBag.Cities = new[] {"New York", "London", "Paris"};
            var message = "This is an HTML element: <input>";
            return View((object) message);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            person.FirstName = "1";
            return View(person);
        }
    }
}