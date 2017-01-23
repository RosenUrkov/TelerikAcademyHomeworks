using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiverseCommunication
{
    class Program
    {
        static string[] numeralSystem = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var digits = GetDigits(input);
            var decoded = Decode(digits);
            var result = ConvertToDec(decoded);
            Console.WriteLine(result);

        }

        static List<string> GetDigits(string input)
        {
            var builder = new StringBuilder();
            List<string> digits = new List<string>();
            for (int i = 0; i < input.Length - 2; i += 3)
            {
                for (int j = i; j < 3 + i; j++)
                {
                    builder.Append(input[j]);
                }
                digits.Add(builder.ToString());
                builder.Clear();
            }

            return digits;
        }

        static List<int> Decode(List<string> digits)
        {
            List<int> decoded = new List<int>();
            foreach (var item in digits)
            {
                for (int i = 0; i < numeralSystem.Length; i++)
                {
                    if (item == numeralSystem[i])
                    {
                        decoded.Add(i);
                        break;
                    }
                }
            }

            return decoded;
        }

        static long ConvertToDec(List<int> decoded)
        {
            long result = 0;
            for (int i = 0; i < decoded.Count; i++)
            {
                result = result * 13 + decoded[i];
            }
            return result;
        }
    }
}
