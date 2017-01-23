using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableLengthCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] codedNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int charCount = int.Parse(Console.ReadLine());
            string[] chars = new string[charCount];
            for (int i = 0; i < charCount; i++)
            {
                chars[i] = Console.ReadLine();
            }

            StringBuilder codedNumbersToBinary = new StringBuilder();
            for (int i = 0; i < codedNumbers.Length; i++)
            {
                codedNumbersToBinary.Append(Convert.ToString(codedNumbers[i], 2).PadLeft(8,'0'));
            }

            string binaryInput = codedNumbersToBinary.ToString().Trim('0');

            string result = Replace(binaryInput, chars);
            Console.WriteLine(result);

        }

        static string Replace(string binaryInput, string[] symbols)
        {
            string result = string.Empty;
            char[] symbol = new char[symbols.Length];
            int[] symbolCount = new int[symbols.Length];
            Dictionary<int, char> myDickt = new Dictionary<int, char>();

            for (int i = 0; i < symbols.Length; i++)
            {
                symbol[i] = symbols[i][0];
                symbolCount[i] = Convert.ToInt32(symbols[i].Substring(1));
                myDickt.Add(symbolCount[i], symbol[i]);
            }

            result = binaryInput;

            for (int i = 0; i < symbols.Length; i++)
            {
                result = result.Replace(new string('1', symbols.Length - i), (myDickt[new string('1', symbols.Length - i).Length]).ToString());
            }

            return result.Replace("0", string.Empty);


        }
    }
}
