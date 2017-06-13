using ConsoleWebServer.Framework.ActionResults;

namespace ConsoleWebServer.Application.Contracts
{
    public interface IApiController
    {
        IActionResult ReturnMe(string param);

        IActionResult GetDateWithCors(string domainName);
    }
}
