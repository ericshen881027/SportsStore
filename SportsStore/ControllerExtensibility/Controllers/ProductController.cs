using System.Web.Mvc;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View("Result", new Result {ControlllerName = "Product", ActionName = "Index"});
        }

        public ActionResult List()
        {
            return View("Result", new Result { ControlllerName = "Product", ActionName = "List" });
        }
    }
}