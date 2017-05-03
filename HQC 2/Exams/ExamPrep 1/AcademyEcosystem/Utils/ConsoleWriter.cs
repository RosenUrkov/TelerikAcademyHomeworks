namespace AcademyEcosystemCLI.Utils
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string template, params object[] parameters)
        {
            Console.WriteLine(template, parameters);
        }
    }
}
