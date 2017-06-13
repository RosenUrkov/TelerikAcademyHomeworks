namespace ConsoleWebServer.Framework
{
    using ConsoleWebServer.Framework.ActionResults;
    using ConsoleWebServer.Framework.Contracts;

    public abstract class Controller
    {
        protected Controller(IHttpRequest request, IActionResultFactory actionResultFactory)
        {
            this.Request = request;
            this.ActionResultFactory = actionResultFactory;
        }

        protected IHttpRequest Request { get; private set; }

        protected IActionResultFactory ActionResultFactory { get; private set; }

        protected IActionResult Content(object model)
        {
            return new ContentActionResult(this.Request, model);
        }

        protected IActionResult Json(object model)
        {
            return new JsonActionResult(this.Request, model);
        }

        protected IActionResult Redirect(string location)
        {
            return new RedirectActionResult(this.Request, location);
        }
    }
}