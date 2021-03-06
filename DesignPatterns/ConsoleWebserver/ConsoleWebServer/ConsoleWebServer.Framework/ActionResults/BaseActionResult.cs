﻿namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;
    using System.Net;

    public abstract class BaseActionResult : IActionResult
    {
        protected BaseActionResult(IHttpRequest request, object model)
        {
            this.Model = model;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        private List<KeyValuePair<string, string>> ResponseHeaders { get; set; }

        private IHttpRequest Request { get; set; }

        private object Model { get; set; }

        public void AddHeader(KeyValuePair<string, string> header)
        {
            this.ResponseHeaders.Add(header);
        }

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(
                this.Request.ProtocolVersion,
                this.GetStatusCode(),
                this.Model.ToString(),
                this.GetContentType()
                );

            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }

        protected virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        protected virtual string GetContentType()
        {
            return HttpResponse.DefaultContentType;
        }
    }
}