using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var words = new List<string>();
            for (int i = 0; i < number; i++)
            {
                words.Add(Console.ReadLine());
            }

            var reordered = Reorder(words);
            // Console.WriteLine(string.Join(" ",reordered));
            Print(reordered);
        }

        static List<string> Reorder(List<string> words)
        {

            for (int i = 0; i < words.Count; i++)
            {
                int one = 1;
                int position = (words[i].Length % (words.Count + 1));
                words.Insert(position, words[i]);
                if (position > i)
                {
                    one = 0;
                }
                words.RemoveAt(i + one);
            }

            return words;
        }

        static void Print(List<string> reordered)
        {
            var result = new StringBuilder();
            int length = 0;

            for (int i = 0; i < reordered.Count; i++)
            {
                if (reordered[i].Length > length)
                {
                    length = reordered[i].Length;
                }
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < reordered.Count; j++)
                {
                    if (reordered[j].Length <= i)
                    {
                        continue;
                    }
                    result.Append(reordered[j][i]);
                }

            }
            Console.WriteLine(result.ToString());
        }
    }
}
