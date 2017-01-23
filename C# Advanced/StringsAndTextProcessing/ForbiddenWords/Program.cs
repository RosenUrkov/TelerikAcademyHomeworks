using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForbiddenWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] forbiddenWords = "PHP CLR Microsoft".Split(' ');
            string text = Console.ReadLine();
            string replacedText = string.Empty;

            foreach (var word in forbiddenWords)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);
       


        }
    }
}
