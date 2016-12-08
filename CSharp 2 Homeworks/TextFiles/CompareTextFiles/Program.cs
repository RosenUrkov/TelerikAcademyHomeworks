using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPath = @"..\..\first.txt";
            string secondPath = @"..\..\second.txt";
            Console.WriteLine(string.Join("\r\n", CompareTextFiles(firstPath, secondPath)));
        }

        static int[] CompareTextFiles(string first, string second)
        {
            int[] equalLines = new int[2];

            using (var firstReader = new StreamReader(first))
            {
                using (var secondReader = new StreamReader(second))
                {
                    while (!firstReader.EndOfStream)
                    {
                        if (firstReader.ReadLine() == secondReader.ReadLine())
                        {
                            equalLines[0]++;
                        }
                        else
                        {
                            equalLines[1]++;
                        }
                    }
                }
            }
            return equalLines;
        }
    }
}
