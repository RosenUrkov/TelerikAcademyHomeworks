using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split('.', ' ', ',');
            List<string> palindromes = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                string reversedWord = string.Join("", words[i].Reverse<char>());
                if(reversedWord==words[i])
                {
                    palindromes.Add(words[i]);
                }
            }

            Console.WriteLine(string.Join(" ",palindromes));
        }
    }
}
