using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    public class RemoteDataController : AsyncController
    {
        private Stopwatch _stopwatch;

        public async Task<ActionResult> Data()
        {
            // Only work for server side, there is no difference in client side.
            var remoteData = await Task<string>.Factory.StartNew(() => new RemoteService().GetRemoteData());
            return View((object) remoteData);
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