using System.Collections.Generic;
using System.Net;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class ContentActionResult : BaseActionResult, IActionResult
    {
        public ContentActionResult(IHttpRequest request, object model)
            : base(request, model)
        {
        }

        protected override string GetContentType()
        {
            return "text/plain; charset=utf-8";
        }
    }
}