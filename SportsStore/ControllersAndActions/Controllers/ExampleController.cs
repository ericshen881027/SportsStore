using System;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public RedirectResult Redirect()
        {
            return RedirectPermanent("/Example/Index");
        }

        public RedirectToRouteResult RedirectToRoute()
        {
            return RedirectToRoute(new {controller = "Example", action = "Index", Id = "MyId"});
        }

        public RedirectToRouteResult RedirectToRouteByAction()
        {
            return RedirectToAction("Index");
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(404, "Url cannot be serviced");
            ////return new HttpNotFoundResult();
        }
    }
}