using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WorkingWithRazor.Infrastructure;

namespace WorkingWithRazor
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomeLocationViewEngine());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
