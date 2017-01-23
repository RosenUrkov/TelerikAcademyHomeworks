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
            string[] words = text.Split(' ', '.', ',');
            List<string> uniqueWords = new List<string>();
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            for (int i = 0; i < words.LongLength; i++)
            {
                if (uniqueWords.Contains(words[i]))
                {
                    continue;
                }
                uniqueWords.Add(words[i]);
            }

            for (int i = 0; i < uniqueWords.Count; i++)
            {
                wordsCount.Add(uniqueWords[i], 0);
            }

            for (int i = 0; i < words.LongLength; i++)
            {
                wordsCount[words[i]]++;
            }

            for (int i = 0; i < wordsCount.Count; i++)
            {
                Console.WriteLine("{0} - {1}", uniqueWords[i], wordsCount[uniqueWords[i]]);
            }
        }
    }
}
