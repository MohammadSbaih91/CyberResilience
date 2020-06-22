using CyberResilience.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberResilience.Attributes
{
    /// <summary>
    /// Serves as a filter to handle errors
    /// </summary>
    public class HandleException : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            Tracer.Error(filterContext.Exception);

            var result = new ViewResult()
            {
                ViewName = "~/Views/Errors/index.cshtml"
            };

            result.TempData["Error"] = filterContext.Exception;

            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
        }
    }
}