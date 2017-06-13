using ConsoleWebServer.Framework.ActionResults;

namespace ConsoleWebServer.Application.Contracts
{
    public interface IHomeController
    {
        IActionResult Index(string param);

        IActionResult LivePage(string param);

        IActionResult LivePageForAjax(string param);

        IActionResult Forum(string param);
    }
}
