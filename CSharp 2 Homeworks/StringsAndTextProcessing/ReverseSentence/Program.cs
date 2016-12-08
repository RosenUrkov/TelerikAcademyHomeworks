using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder reversedText = new StringBuilder();

            string[] words = text.Split(new char[] { '.', ',', ' ', '!', '?', '"' }, StringSplitOptions.RemoveEmptyEntries);
            string[] symbols = text.Split(words, StringSplitOptions.RemoveEmptyEntries);
            int symbolsCounter = 0;

            words = words.Reverse().ToArray();            

            for (int i = 0; i < words.Length; i++)
            {
                reversedText.Append(words[i]);

                if ((symbolsCounter != symbols.Length - 1) && (symbols[symbolsCounter + 1] == ","))
                {
                    reversedText.Append(symbols[symbolsCounter + 1]);
                    reversedText.Append(symbols[symbolsCounter]);
                    symbolsCounter += 2;
                    continue;
                }

                reversedText.Append(symbols[symbolsCounter]);
                symbolsCounter++;
            }
            //reversedText.Append(words[words.Length - 1]);
            Console.WriteLine(reversedText.ToString());
        }
    }
}
