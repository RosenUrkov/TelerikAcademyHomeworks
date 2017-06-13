using System;
using ConsoleWebServer.Application.Contracts;

namespace ConsoleWebServer.Application.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
