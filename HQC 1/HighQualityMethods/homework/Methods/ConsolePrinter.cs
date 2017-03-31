namespace Methods
{
    using System;

    public class ConsolePrinter
    {
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }

        public static void Print(double number)
        {
            Console.WriteLine(number);
        }

        public static void PrintWIthFormating(string formatTemplate, params object[] text)
        {
            Console.WriteLine(formatTemplate, text);
        }

        public static void PrintNumbeWithFormating(int number, string formatTemplate)
        {
            Console.WriteLine(formatTemplate, number);
        }

        public static void PrintNumbeWithFormating(double number, string formatTemplate)
        {
            Console.WriteLine(formatTemplate, number);
        }
    }
}
