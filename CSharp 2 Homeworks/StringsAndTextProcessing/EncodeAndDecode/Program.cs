using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeAndDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            string cypher = Console.ReadLine();
            string text = Console.ReadLine();
            StringBuilder encodedText = new StringBuilder();
            StringBuilder decodedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                encodedText.Append((char)(text[i] ^ cypher[i % cypher.Length]));
            }

            Console.WriteLine(encodedText.ToString());

            for (int i = 0; i < encodedText.Length; i++)
            {
                decodedText.Append((char)(encodedText[i] ^ cypher[i % cypher.Length]));
            }

            Console.WriteLine(decodedText.ToString());
        }
    }
}
