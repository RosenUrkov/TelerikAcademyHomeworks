using Ninject;
using SimpleApp.Common.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleApp.Common.Filters
{
    public class LoggerFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger logger;

        public LoggerFilterAttribute()
        {
            // not pretty, but could not find another way
            var serviceLocator = (IKernel)DependencyResolver.Current.GetService(typeof(IKernel));
            this.logger = serviceLocator.Get<ILogger>();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {            
            logger.Log(filterContext.HttpContext.Request.RawUrl);
            base.OnActionExecuting(filterContext);
        }
    }
}