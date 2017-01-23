using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sub_StringInText
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            //string[] leftover = text.Split(new string[] { pattern }, StringSplitOptions.None);
            //Console.WriteLine(leftover.Length - 1);
            Console.WriteLine(SearchForText(text, pattern));
        }

        static int SearchForText(string text, string pattern)
        {
            int counter = 0;
            int startIndex = 0;
            while (true)
            {
                int index = text.IndexOf(pattern, startIndex, StringComparison.CurrentCultureIgnoreCase);

                if (index == -1)
                {
                    return counter;
                }

                startIndex = index + 1;
                counter++;

            }

        }
    }
}
