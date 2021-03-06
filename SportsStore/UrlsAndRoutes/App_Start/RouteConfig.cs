﻿using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            ////routes.MapRoute(string.Empty, "Shop/OldAction", new {controller = "Home", action = "Index"});

            ////routes.MapRoute("ShopSchema", "Shop/{action}", new {controller = "Home"});

            ////routes.MapRoute(string.Empty, "X{controller}/{action}");

            ////routes.MapRoute("MyRoute", "{controller}/{action}", new {action = "Index", controller = "Home"});

            ////routes.MapRoute(string.Empty, "Public/{controller}/{action}", new {action = "Index", controller = "Home"});
            ////var mapRoute = routes.MapRoute("AdditionalContrllerRoute", "{controller}/{action}/{id}",
            ////    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            ////    new[] { "UrlsAndRoutes.AdditionalControllers" });
            ////mapRoute.DataTokens["UseNamespaceFallback"] = false;

            ////routes.RouteExistingFiles = true;

            ////routes.IgnoreRoute("Content/{filename}.html");
            ////routes.MapRoute("DiskFile", "Content/StaticContent.html", new { controller = "Customer", action = "List" });
            ////routes.MapRoute("ChromeRoute", "{*catchall}", new { controller = "Home", action = "Index" },
            ////    new { customConstraint = new UserAgentConstraint("Chrome") },
            ////new[] { "UrlsAndRoutes.AdditionalControllers" });

            ////routes.MapRoute("NewRoute", "App/Do{action}", new {controller = "Home"});

            ////routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            ////    new {controller = "Home", action = "Index", id = UrlParameter.Optional},
            ////    new[] {"UrlsAndRoutes.Controllers"});

            routes.Add(new Route("SayHello/Test", new CustomRouteHandler()));

            routes.Add(new LegacyRoute("~/articles/Windows_3.1_Overview.html", "~/old/.NET_1.0_Class_Library"));

            routes.MapRoute("MyRoute", "{controller}/{action}", null, new[] { "UrlsAndRoutes.Controllers" });
            routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" }, new[] { "UrlsAndRoutes.Controllers" });
        }
    }
}
