using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTags
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new string[] { "<upcase>", "</upcase>" }, StringSplitOptions.None);
            StringBuilder uppedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {

                if ((i & 1) == 1)
                {
                    uppedText.Append(text[i].ToUpper());
                }
                else
                {
                    uppedText.Append(text[i]);
                }
            }

            Console.WriteLine(uppedText.ToString());
        }
    }
}
