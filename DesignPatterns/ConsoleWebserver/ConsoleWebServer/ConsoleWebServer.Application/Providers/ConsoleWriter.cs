using System;
using ConsoleWebServer.Application.Contracts;

namespace ConsoleWebServer.Application.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
