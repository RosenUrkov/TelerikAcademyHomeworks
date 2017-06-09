namespace ConsoleWebServer.Framework.ActionResults
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;

    public class JsonActionResult : BaseActionResult, IActionResult
    {
        public JsonActionResult(IHttpRequest request, object model)
            : base(request, JsonConvert.SerializeObject(model))
        {
        }

        protected override string GetContentType()
        {
            return "application/json";
        }
    }
}
