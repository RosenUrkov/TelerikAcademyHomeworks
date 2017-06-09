namespace ConsoleWebServer.Framework.Contracts
{
    public interface IHandler
    {
        void SetSuccessor(IHandler successor);

        HttpResponse HandleRequest(IHttpRequest request);
    }
}
