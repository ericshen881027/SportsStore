using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {
        private Stopwatch _stopwatch;

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _stopwatch.Stop();
            filterContext.HttpContext.Response.Write(
                $"<div>Result elapsed time: {_stopwatch.Elapsed.TotalSeconds}</div>");
        }
    }
}