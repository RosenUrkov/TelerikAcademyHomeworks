using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenate_Text_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = @"..\..\first.txt";
            string second = @"..\..\second.txt";
            try
            {
                Console.WriteLine(ConcatenataFiles(first, second));
            }
            catch (Exception exc)
            {

                Console.WriteLine(exc.Message);
            }
        }

        static string ConcatenataFiles(string fistPath, string secondPath)
        {
            StringBuilder concatenatedText = new StringBuilder();

            concatenatedText.Append(ReadFile(fistPath));
            concatenatedText.Append(ReadFile(secondPath));

            return concatenatedText.ToString();


        }

        static string ReadFile(string path)
        {
            string text = string.Empty;
            using (var stream = new StreamReader(path))
            {
                text = stream.ReadToEnd();
            }
            return text;

        }
    }
}
