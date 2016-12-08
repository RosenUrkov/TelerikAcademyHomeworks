using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] letters = text.ToCharArray();
            List<char> uniqueChars = new List<char>();
            Dictionary<char, int> lettersCount = new Dictionary<char, int>();

            for (int i = 0; i < letters.LongLength; i++)
            {
                if (uniqueChars.Contains(letters[i]))
                {
                    continue;
                }
                uniqueChars.Add(letters[i]);
            }

            for (int i = 0; i < uniqueChars.Count; i++)
            {
                lettersCount.Add(uniqueChars[i], 0);
            }

            for (int i = 0; i < letters.LongLength; i++)
            {
                lettersCount[letters[i]]++;
            }

            for (int i = 0; i < lettersCount.Count; i++)
            {
                Console.WriteLine("{0} - {1}",uniqueChars[i],lettersCount[uniqueChars[i]]);
            }
        }
    }
}
