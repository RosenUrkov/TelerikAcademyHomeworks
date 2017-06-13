using ConsoleWebServer.Framework.ActionResults;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IActionResultFactory
    {
        IActionResult GetContentActionResult(IHttpRequest request, object model);

        IActionResult GetJsonActionResult(IHttpRequest request, object model);

        IActionResult GetRedirectActionResult(IHttpRequest request, string location);

        IActionResult GetActionResultWIthCors(IHttpRequest request, object model);

        IActionResult GetActionResultWithoutCaching(IHttpRequest request, object model, string corsSettings);

        IActionResult GetActionResultWIthCorsWithoutCaching(IHttpRequest request, object model, string corsSettings);
    }
}
