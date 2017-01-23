using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RemoveWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = @"..\..\text.txt";
            string wordsPath = @"..\..\wordsToRemove.txt";
            RemoveWords(textPath, wordsPath);
        }

        static void RemoveWords(string textPath, string wordsPath)
        {
            var words = new List<string>();
            using (var reader = new StreamReader(wordsPath))
            {
                words = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            string content = string.Empty;
            using (var reader = new StreamReader(textPath))
            {
                content = reader.ReadToEnd();
            }

            for (int i = 0; i < words.Count; i++)
            {
                content = content.Replace(words[i], string.Empty);
            }

            content = string.Join(" ", content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            using (var writer = new StreamWriter(textPath))
            {
                writer.WriteLine(content);
            }
            //dasfas ceca dasgwa trepni fsafw trep gagw mile kitic ebanie dqdokoleda beibi
        }
    }
}
