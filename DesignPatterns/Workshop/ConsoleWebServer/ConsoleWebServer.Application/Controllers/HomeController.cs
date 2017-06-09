namespace ConsoleWebServer.Application.Controllers
{
    using ConsoleWebServer.Application.Contracts;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResults;
    using ConsoleWebServer.Framework.Contracts;

    public class HomeController : Controller, IHomeController
    {
        public HomeController(IHttpRequest request, IActionResultFactory actionResultFactory)
            : base(request, actionResultFactory)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult LivePage(string param)
        {
            return new ActionResultWithoutCaching(new ContentActionResult(this.Request, "Live page with no caching"));
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new ActionResultWIthCors(
                new ActionResultWithoutCaching(
                    new ContentActionResult(this.Request, "Live page with no caching and CORS")),
                "*");
        }

        public IActionResult Forum(string param)
        {
            return this.Redirect("https://telerikacademy.com/Forum/Home");
        }
    }
}