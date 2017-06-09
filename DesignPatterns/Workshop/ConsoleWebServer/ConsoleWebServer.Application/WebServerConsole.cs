namespace ConsoleWebServer.Application
{
    using ConsoleWebServer.Application.Contracts;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Contracts;
    using System;
    using System.Text;

    public class WebServerConsole : IWebServerConsole
    {
        private readonly IResponseProvider responseProvider;
        private readonly IReader reader;
        private readonly IWriter writer;

        public WebServerConsole(IResponseProvider responseProvider, IReader reader, IWriter writer)
        {
            this.responseProvider = responseProvider;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = this.reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this.responseProvider.GetResponse(requestBuilder.ToString());
                    this.writer.WriteLine(response.ToString());
                    requestBuilder.Clear();
                    continue;
                }

                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}