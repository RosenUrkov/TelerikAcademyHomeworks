namespace Matrix
{
    using System;

    public class ConsolePrinter : IPrinter
    {
        public void Write(string template, int number)
        {
            Console.Write(template, number);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
