using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes.Infrastructure
{
    public class LegacyRoute : RouteBase
    {
        private readonly string[] _targetUrls;
        public LegacyRoute(params string[] targetUrls)
        {
            _targetUrls = targetUrls;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData routeData = null;
            var appRelativeCurrentExecutionFilePath = httpContext.Request.AppRelativeCurrentExecutionFilePath;
            if (_targetUrls.Contains(appRelativeCurrentExecutionFilePath, StringComparer.OrdinalIgnoreCase))
            {
                routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller", "Legacy");
                routeData.Values.Add("action", "GetLegacyUrl");
                routeData.Values.Add("legacyUrl", appRelativeCurrentExecutionFilePath);
            }

            return routeData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData result = null;
            if (values.ContainsKey("legacyUrl") &&
                _targetUrls.Contains((string) values["legacyUrl"], StringComparer.OrdinalIgnoreCase))
            {
                result = new VirtualPathData(this,
                    new UrlHelper(requestContext).Content((string) values["legacyUrl"]).Substring(1));
            }

            return result;
        }
    }
}