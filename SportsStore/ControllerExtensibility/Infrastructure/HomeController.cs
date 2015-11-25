using System.Web.Mvc;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Infrastructure
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Result", new Result {ControlllerName = "Home", ActionName = "Index"});
        }

        [Local]
        [ActionName("Index")]
        public ActionResult LocalIndex()
        {
            return View("Result", new Result { ControlllerName = "Home", ActionName = "LocalIndex" });
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write($"You requested the {actionName} action");
        }
    }
}