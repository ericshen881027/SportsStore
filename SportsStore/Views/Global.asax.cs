using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Views.Infrastructure;

namespace Views
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ViewEngines.Engines.Add(new DebugDataViewEngine());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
