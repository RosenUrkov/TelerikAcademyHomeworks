using ConsoleWebServer.Framework.Contracts;
using System.Net;

namespace ConsoleWebServer.Framework.Handlers
{
    public abstract class Handler : IHandler
    {
        private IHandler Successor { get; set; }

        public void SetSuccessor(IHandler successor)
        {
            this.Successor = successor;
        }

        public HttpResponse HandleRequest(IHttpRequest request)
        {
            if (this.CanHandle(request))
            {
                return this.Handle(request);
            }

            if(this.Successor != null)
            {
                return this.Successor.HandleRequest(request);
            }

            return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, "Request cannot be handled.");
        }

        protected abstract bool CanHandle(IHttpRequest request);

        protected abstract HttpResponse Handle(IHttpRequest request);
    }
}
