using System.Web.Mvc;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View("Result", new Result {ControlllerName = "Customer", ActionName = "Index"});
        }

        public ActionResult List()
        {
            return View("Result", new Result { ControlllerName = "Customer", ActionName = "List" });
        }

        [NonAction]
        public ActionResult MyAction()
        {
            return View();
        }
    }
}