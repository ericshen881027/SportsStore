using System.Web.Mvc;

namespace ControllerExtensibility.Infrastructure
{
    public class ActionInvokerController : Controller
    {
        public ActionInvokerController()
        {
            ActionInvoker = new CustomActionInvoker();
        }
    }
}