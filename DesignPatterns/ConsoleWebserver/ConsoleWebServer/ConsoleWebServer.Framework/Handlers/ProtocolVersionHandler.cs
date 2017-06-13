using ConsoleWebServer.Framework.Contracts;
using System;
using System.Linq;
using System.Net;
using System.Reflection;

namespace ConsoleWebServer.Framework.Handlers
{
    public class ProtocolVersionHandler : Handler, IHandler
    {
        protected override bool CanHandle(IHttpRequest request)
        {
            return request.ProtocolVersion.Major < 3;
        }

        protected override HttpResponse Handle(IHttpRequest request)
        {
            HttpResponse response;
            try
            {
                var controller = CreateController(request);
                var actionInvoker = new ActionInvoker();
                var actionResult = actionInvoker.InvokeAction(controller, request.Action);
                response = actionResult.GetResponse();
            }
            catch (HttpNotFoundException exception)
            {
                response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
            }
            catch (Exception exception)
            {
                response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
            }
            return response;
        }

        private static Controller CreateController(IHttpRequest request)
        {
            var controllerClassName = request.Action.ControllerName + "Controller";
            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                        x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));
            if (type == null)
            {
                throw new HttpNotFoundException(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }
            var instance = (Controller)Activator.CreateInstance(type, request);
            return instance;
        }
    }
}
