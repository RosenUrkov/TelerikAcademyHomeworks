using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string format = "\\u{0:X4}";
            foreach (var character in text)
            {
                Console.Write(format, (ushort)character);
            }
        }
    }
}
