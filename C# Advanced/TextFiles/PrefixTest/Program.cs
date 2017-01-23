using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrefixTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\input.txt";
            Console.WriteLine(string.Join(" ", RemoveElementsFromFile(path)));
        }

        static List<string> RemoveElementsFromFile(string path)
        {
            string content = string.Empty;

            using (var reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }

            string[] words = content.Split(' ');
            var correctWords = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                bool isCorrect = true;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (((words[i][j] >= '0' && words[i][j] <= '9') || (words[i][j] >= 'a' && words[i][j] <= 'z') || (words[i][j] >= 'A' && words[i][j] <= 'Z') || (words[i][j] == '_')))
                    {
                        isCorrect = false;
                        break;
                    }
                }

                if (isCorrect)
                {
                    correctWords.Add(words[i]);
                }
            }

            return correctWords;
        }
    }
}
