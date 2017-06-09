namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;
    using System.Net;

    public class RedirectActionResult : BaseActionResult, IActionResult
    {
        public RedirectActionResult(IHttpRequest request, string location)
            : base(request, location)
        {
            this.AddHeader(new KeyValuePair<string, string>("Location", location));
        }

        protected override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.Redirect;
        }
    }
}
