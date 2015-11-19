using System;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
            {
                var actualValue = (int) ((ArgumentOutOfRangeException) filterContext.Exception).ActualValue;
                filterContext.Result = new ViewResult
                {
                    ViewName = "RangeError",
                    ViewData = new ViewDataDictionary(actualValue)
                };

                filterContext.ExceptionHandled = true;
            }
        }
    }
}