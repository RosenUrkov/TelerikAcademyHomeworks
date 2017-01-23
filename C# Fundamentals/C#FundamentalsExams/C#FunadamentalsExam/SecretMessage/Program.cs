using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int counterOfFrases = 1;
            string decodedMessage = string.Empty;

            while (true)
            {
                int startOfDecoding = 0;

                try
                {
                    startOfDecoding = int.Parse(Console.ReadLine());
                }
                catch(FormatException)
                {
                    break;
                }

                int endOfDecoding = int.Parse(Console.ReadLine());
                string decodingFrase = Console.ReadLine();


                if (startOfDecoding < 0)
                {
                    startOfDecoding = decodingFrase.Length + startOfDecoding;
                }
                if (endOfDecoding < 0)
                {
                    endOfDecoding = decodingFrase.Length + endOfDecoding;
                }


                if ((counterOfFrases & 1) == 1)
                {

                    for (int i = startOfDecoding; i <= endOfDecoding; i += 3)
                    {

                        decodedMessage += decodingFrase[i];
                    }
                }
                
                else if ((counterOfFrases & 1) == 0)
                {

                    for (int i = startOfDecoding; i <= endOfDecoding; i += 4)
                    {

                        decodedMessage += decodingFrase[i];
                    }

                }               
                counterOfFrases++;
            }
            Console.WriteLine(decodedMessage);

        }
    }
}

