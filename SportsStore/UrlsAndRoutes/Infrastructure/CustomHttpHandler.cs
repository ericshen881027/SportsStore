using System.Web;

namespace UrlsAndRoutes.Infrastructure
{
    public class CustomHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Hello");
        }

        public bool IsReusable => false;
    }
}