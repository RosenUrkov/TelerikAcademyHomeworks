namespace ConsoleWebServer.Framework
{
    using ConsoleWebServer.Application.Contracts;
    using ConsoleWebServer.Framework.Contracts;
    using ConsoleWebServer.Framework.Providers;
    using System.IO;

    public class RequestParser : IRequestParser
    {
        private readonly IReaderFactory readerFactory;
        private readonly IHttpRequestFactory requestFactory;

        public RequestParser(IReaderFactory readerFactory, IHttpRequestFactory requestFactory)
        {
            this.readerFactory = readerFactory;
            this.requestFactory = requestFactory;
        }

        public IHttpRequest Parse(string requestAsString)
        {
            var textReader = this.readerFactory.GetMessageReader(requestAsString);
            var firstLine = textReader.ReadLine();
            var requestObject = this.CreateRequest(firstLine);

            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                this.AddHeaderToRequest(requestObject, line);
            }

            return requestObject;
        }

        private IHttpRequest CreateRequest(string firstRequestLine)
        {
            var firstRequestLineParts = firstRequestLine?.Split(' ');
            if (firstRequestLine == null || firstRequestLineParts.Length != 3)
            {
                throw new ParserException(
                    "Invalid format for the first request line. Expected format: [Method] [Uri] HTTP/[Version]");
            }

            return this.requestFactory.CreateHttpRequest(firstRequestLineParts[0], firstRequestLineParts[1], firstRequestLineParts[2]);
        }

        private void AddHeaderToRequest(IHttpRequest request, string headerLine)
        {
            var headerParts = headerLine.Split(new[] { ':' }, 2);
            var headerName = headerParts[0].Trim();
            var headerValue = headerParts.Length == 2 ? headerParts[1].Trim() : string.Empty;
            request.AddHeader(headerName, headerValue);
        }
    }
}