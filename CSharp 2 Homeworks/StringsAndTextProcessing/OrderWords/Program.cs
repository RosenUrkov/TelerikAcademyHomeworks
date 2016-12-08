using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            SortLength(words);
            Console.WriteLine(string.Join("\r\n", words));
        }

        static void SortLength(string[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = elements.Length - i - 1; j > 0; j--)
                {
                    if (string.Compare(elements[j - 1], elements[j], false) == 1)
                    {
                        string temp = elements[j];
                        elements[j] = elements[j - 1];
                        elements[j - 1] = temp;
                    }
                }

            }
        }
    }
}
