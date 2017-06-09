using ConsoleWebServer.Framework.Contracts;
using System;
using System.Net;

namespace ConsoleWebServer.Framework.Handlers
{
    public class HeadHandler : Handler, IHandler
    {    
        protected override bool CanHandle(IHttpRequest request)
        {
            return request.Method.ToLower() == "head";
        }

        protected override HttpResponse Handle(IHttpRequest request)
        {
            return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Empty);
        }
    }
}
