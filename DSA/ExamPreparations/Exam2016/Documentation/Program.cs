using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine().ToLower();

            var startIndex = 0;
            var endIndex = str.Length - 1;

            var result = 0;
            while (startIndex < endIndex)
            {
                while (!char.IsLetter(str[startIndex]))
                {
                    if(startIndex >= endIndex)
                    {
                        Console.WriteLine(result);
                        return;
                    }

                    startIndex++;
                }
                while (!char.IsLetter(str[endIndex]))
                {
                    endIndex--;
                }

                if (str[startIndex] != str[endIndex])
                {
                    var res = Math.Abs(str[endIndex] - str[startIndex]);
                    result += res < 13 ? res : 26 - res;
                }

                startIndex++;
                endIndex--;
            }

            Console.WriteLine(result);
        }
    }
}
