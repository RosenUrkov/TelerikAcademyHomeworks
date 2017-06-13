using System;
using ConsoleWebServer.Application.Contracts;
using System.IO;

namespace ConsoleWebServer.Framework.Providers
{
    public class MessageReader : IReader
    {
        private readonly StringReader reader;

        public MessageReader(string text)
        {
            this.reader = new StringReader(text);
        }

        public string ReadLine()
        {
            return this.reader.ReadLine();
        }
    }
}
