using System;
using System.Net;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IHttpResponseFactory
    {
        HttpResponse CreateHttpResponse(Version httpVersion,
            HttpStatusCode statusCode,
            string body,
            string contentType = HttpResponse.DefaultContentType
            );
    }
}
