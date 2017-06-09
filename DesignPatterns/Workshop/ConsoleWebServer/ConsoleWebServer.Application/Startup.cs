using ConsoleWebServer.Application.Container;
using ConsoleWebServer.Application.Contracts;
using ConsoleWebServer.Framework;
using Ninject;

namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new WebServerNinjectModule());

            var webSever = kernel.Get<IWebServerConsole>();
            webSever.Start();
        }
    }
}