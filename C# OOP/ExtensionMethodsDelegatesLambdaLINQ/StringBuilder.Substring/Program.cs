namespace StringBuilder.Substring
{
    using System.Text;
    using System;
    public class Program
    {       
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var builder = new StringBuilder();
            builder.Append(text);
            text = text.Substring(3, 5);
            Console.WriteLine(text);
            builder = builder.Substring(3, 5);
            Console.WriteLine(builder);
        }
    }
}
