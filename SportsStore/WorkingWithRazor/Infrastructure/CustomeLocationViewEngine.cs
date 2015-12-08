using System.Web.Mvc;

namespace WorkingWithRazor.Infrastructure
{
    public class CustomeLocationViewEngine : RazorViewEngine
    {
        public CustomeLocationViewEngine()
        {
            ViewLocationFormats = new[] {"~/Views/{1}/{0}.cshtml", "~/Views/Common/{0}.cshtml"};
        }
    }
}