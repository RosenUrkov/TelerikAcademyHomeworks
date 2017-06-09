using ConsoleWebServer.Application.Contracts;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IReaderFactory
    {
        IReader GetMessageReader(string text);
    }
}
