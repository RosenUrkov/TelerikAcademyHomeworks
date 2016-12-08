using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<char> singleLetters = new List<char>();

            char firstChar = text[0];
            singleLetters.Add(firstChar);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != firstChar)
                {
                    singleLetters.Add(text[i]);
                    firstChar = text[i];
                }
            }

            Console.WriteLine(string.Join("", singleLetters));
        }
    }
}
