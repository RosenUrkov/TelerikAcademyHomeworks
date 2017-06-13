namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;
    using System.Net;

    using ConsoleWebServer.Framework.Handlers;
    using System.Reflection;
    using ActionResults;
    using ConsoleWebServer.Framework.Contracts;
    using System.Collections.Generic;

    public class ResponseProvider : IResponseProvider
    {
        private readonly IHandler handler;
        private readonly IRequestParser requestParser;
        private readonly IHttpResponseFactory responseFactory;

        public ResponseProvider(IHandler handler, IRequestParser requestParser, IHttpResponseFactory responseFactory)
        {
            this.handler = handler;
            this.requestParser = requestParser;
            this.responseFactory = responseFactory;
        }

        public HttpResponse GetResponse(string requestAsString)
        {
            IHttpRequest request;
            try
            {
                request = this.requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return this.responseFactory.CreateHttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.handler.HandleRequest(request);
            return response;
        }       
    }
}