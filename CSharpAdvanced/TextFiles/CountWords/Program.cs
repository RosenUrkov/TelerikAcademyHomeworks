using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsPath = @"..\..\words.txt";
            string textPath = @"..\..\text.txt";
            string resultPath = @"..\..\result.txt";
            SortedDictionary<string, int> wordsCount = CountWords(textPath, wordsPath);
            WriteResult(resultPath, wordsCount);

        }

        static SortedDictionary<string, int> CountWords(string textPath, string wordsPath)
        {
            var words = new List<string>();
            using (var reader = new StreamReader(wordsPath))
            {
                words = reader.ReadLine().Split(' ').ToList();
            }

            var wordsCount = new SortedDictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
                wordsCount.Add(words[i], 0);
            }

            var textContent = new List<string>();
            using (var reader = new StreamReader(textPath))
            {
                textContent = reader.ReadLine().Split(' ').ToList();
            }

            for (int i = 0; i < textContent.Count; i++)
            {
                wordsCount[textContent[i]]++;
            }

            return wordsCount;
        }

        static void WriteResult(string path, SortedDictionary<string, int> wordsCount)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var item in wordsCount)
                {
                    writer.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }

        }
    }
}
