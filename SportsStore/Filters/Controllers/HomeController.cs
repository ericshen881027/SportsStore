using System;
using System.Diagnostics;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        private Stopwatch _stopwatch;

        [Authorize(Users = "adam, steve, jacqui", Roles = "admin")]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return $"The id value is :{id}";
            }

            throw new ArgumentOutOfRangeException(nameof(id), id, string.Empty);
        }

        [ProfileAction]
        [ProfileResult]
        [ProfileAll]
        public string FilterTest()
        {
            return "This is the FilterTest action";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _stopwatch.Stop();
            filterContext.HttpContext.Response.Write($"<div>Total elapsed time: {_stopwatch.Elapsed.TotalSeconds}</div>");
        }
    }
}