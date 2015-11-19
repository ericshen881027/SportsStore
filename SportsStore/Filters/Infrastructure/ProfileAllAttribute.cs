using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class ProfileAllAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _stopwatch.Stop();
            filterContext.HttpContext.Response.Write($"<div>Total elapsed time: {_stopwatch.Elapsed.TotalSeconds}</div>");
        }
    }
}