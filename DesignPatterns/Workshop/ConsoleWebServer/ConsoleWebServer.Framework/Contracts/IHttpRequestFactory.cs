namespace ConsoleWebServer.Framework.Providers
{
    public interface IHttpRequestFactory
    {
        HttpRequest CreateHttpRequest(string method, string uri, string httpVersion);
    }
}