using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlsGoneWild
{
    class Program
    {
        static SortedSet<string> result = new SortedSet<string>();

        static int shirts = 0;
        static string skirts = "";
        static int girlsCount = 0;

        static string[] girls;
        static bool[] usedSkirts;

        static void Main(string[] args)
        {
            shirts = int.Parse(Console.ReadLine());
            skirts = Console.ReadLine();
            girlsCount = int.Parse(Console.ReadLine());

            girls = new string[girlsCount];
            usedSkirts = new bool[skirts.Length];

            Recursion(0, 0);

            Console.WriteLine(result.Count);
            Console.WriteLine(string.Join("\n", result));
        }

        static void Recursion(int current, int shirtStartIndex)
        {
            if (current == girlsCount)
            {
                result.Add(string.Join("-", girls));
                return;
            }

            for (int i = shirtStartIndex; i < shirts; i++)
            {
                for (int j = 0; j < skirts.Length; j++)
                {
                    if (usedSkirts[j])
                    {
                        continue;
                    }

                    usedSkirts[j] = true;

                    girls[current] = i.ToString() + skirts[j];
                    Recursion(current + 1, i + 1);

                    usedSkirts[j] = false;
                }
            }
        }
    }
}
