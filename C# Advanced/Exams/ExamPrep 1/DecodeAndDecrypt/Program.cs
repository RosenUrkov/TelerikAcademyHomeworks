using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeAndDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int cypherLength = 0;
            StringBuilder cypherLengthNumber = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(input[i]))
                {
                    cypherLengthNumber.Insert(0, input[i]);
                }
                else
                {
                    break;
                }
            }
            cypherLength = Convert.ToInt32(cypherLengthNumber.ToString());

            string encodedMessage = input.Remove(input.Length - cypherLengthNumber.Length);
            string decodedMessage = Decode(encodedMessage);

            string cypher = GetCypher(decodedMessage, cypherLength);
            decodedMessage = decodedMessage.Replace(cypher, string.Empty).Trim();

            try
            {
                string decryptedMessage = Decrypt(decodedMessage, cypher);
                Console.WriteLine(decryptedMessage);
            }
            catch (Exception ex)
            {
                throw new IndexOutOfRangeException();
            }

        }

        static string Decode(string encodedMessage)
        {
            StringBuilder compressed = new StringBuilder();
            StringBuilder decoded = new StringBuilder();

            for (int i = 0; i < encodedMessage.Length - 1; i++)
            {
                if (char.IsDigit(encodedMessage[i]))
                {
                    compressed.Append(encodedMessage[i]);

                    if (!(char.IsDigit(encodedMessage[i + 1])))
                    {
                        int compressedNumber = Convert.ToInt32(compressed.ToString());
                        string temp = (encodedMessage.Replace(compressedNumber.ToString(), new string(encodedMessage[i + 1], compressedNumber - 1)));
                        temp = temp.Remove(0, i - compressed.Length + 1);
                        compressed.Clear();
                        decoded.Append(temp.Substring(temp.IndexOf(encodedMessage[i + 1]), compressedNumber - 1));
                    }
                }
                else
                {
                    decoded.Append(encodedMessage[i]);
                }

            }
            decoded.Append(encodedMessage[encodedMessage.Length - 1]);
            return decoded.ToString();
        }

        static string GetCypher(string decodedMessage, int cypherLength)
        {
            StringBuilder cypher = new StringBuilder();
            for (int i = 0; i < cypherLength; i++)
            {
                cypher.Insert(0, decodedMessage[decodedMessage.Length - 1 - i]);
            }
            return cypher.ToString();
        }

        static string Decrypt(string decodedMessage, string cypher)
        {
            int length = Math.Max(decodedMessage.Length, cypher.Length);
            var decryptedMessage = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                if (decryptedMessage.Length == decodedMessage.Length)
                {
                    decodedMessage = decryptedMessage.ToString();
                }
                decryptedMessage.Insert(i % decodedMessage.Length, ((char)(((decodedMessage[i % decodedMessage.Length] - 'A') ^ (cypher[i % cypher.Length] - 'A')) + 'A')));
                if (decryptedMessage.Length > decodedMessage.Length)
                {

                    decryptedMessage = decryptedMessage.Remove(i % decodedMessage.Length + 1, 1);
                }

            }

            return decryptedMessage.ToString();
        }


    }
}
