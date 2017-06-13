using System;
using System.Collections.Generic;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class ActionResultWIthCors : IActionResult
    {
        private readonly IActionResult actionResult;

        public ActionResultWIthCors(IActionResult actionResult, string corsSettings)
        {
            this.actionResult = actionResult;
            this.actionResult.AddHeader(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
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
