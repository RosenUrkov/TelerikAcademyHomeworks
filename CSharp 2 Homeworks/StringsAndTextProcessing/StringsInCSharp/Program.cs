using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsInCSharp
{
    class Program
    {

        static string Reverse(string text)
        {
            string result = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                result += text[text.Length - 1 - i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string reversed = Reverse(text);
            Console.WriteLine(reversed);
        }
    }
}
