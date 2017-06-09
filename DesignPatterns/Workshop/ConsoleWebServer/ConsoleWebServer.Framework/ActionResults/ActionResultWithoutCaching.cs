using System;
using System.Collections.Generic;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class ActionResultWithoutCaching : IActionResult
    {
        private readonly IActionResult actionResult;

        public ActionResultWithoutCaching(IActionResult actionResult)
        {
            this.actionResult = actionResult;
            this.actionResult.AddHeader(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }

        public void AddHeader(KeyValuePair<string, string> header)
        {
            this.actionResult.AddHeader(header);
        }

        public HttpResponse GetResponse()
        {
            return this.actionResult.GetResponse();
        }
    }
}
