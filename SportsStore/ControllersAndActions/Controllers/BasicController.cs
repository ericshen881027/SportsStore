using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersAndActions.Controllers
{
    public class BasicController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            var controller = (string)requestContext.RouteData.Values["controller"];
            var action = (string)requestContext.RouteData.Values["action"];

            if (string.Equals(action, "redirect", StringComparison.OrdinalIgnoreCase))
            {
                requestContext.HttpContext.Response.Redirect("/Derived/Index");
            }
            else
            {
                requestContext.HttpContext.Response.Write($"Controller: {controller}, Action: {action}");
            }
        }
    }
}