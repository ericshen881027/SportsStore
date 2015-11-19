using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        private readonly bool _allowedParam;

        public CustomAuthAttribute(bool allowedParam)
        {
            _allowedParam = allowedParam;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
            {
                return _allowedParam;
            }

            return true;
        }
    }
}