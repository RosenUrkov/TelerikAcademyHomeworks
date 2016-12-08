using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExtractSentences
{

    class Program
    {
        static char[] splitChars;

        static void Main(string[] args)
        {
            string searchingWord = Console.ReadLine();
            string text = Console.ReadLine();
            GetSplitChars(text);
            string result = SentencesValidation(text, searchingWord);
            Console.WriteLine(result);

        }

        private static void GetSplitChars(string text)
        {
            List<char> charList = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!(char.IsLetter(text[i])) && (!charList.Contains(text[i])))
                {
                    charList.Add(text[i]);
                }
            }
            splitChars = charList.ToArray();
        }

        static string SentencesValidation(string text, string word)
        {
            string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            StringBuilder validSentences = new StringBuilder();

            for (int i = 0; i < sentences.Length; i++)
            {
                string[] words = sentences[i].Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j] == word)
                    {
                        validSentences.Append(sentences[i].Trim());
                        validSentences.Append(". ");
                        break;
                    }
                }
            }
            return validSentences.ToString().Trim();
        }


    }
}
