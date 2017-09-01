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
        static HashSet<string> usedPairs = new HashSet<string>();

        static int shirts = 0;
        static string skirts = "";
        static int girlsCount = 0;

        static string[] girls;

        static bool[] usedShirts;
        static bool[] usedSkirts;

        static void Main(string[] args)
        {
            shirts = int.Parse(Console.ReadLine());
            skirts = Console.ReadLine();
            girlsCount = int.Parse(Console.ReadLine());

            girls = new string[girlsCount];

            usedShirts = new bool[shirts];
            usedSkirts = new bool[skirts.Length];

            Recursion(0);

            Console.WriteLine(result.Count);
            Console.WriteLine(string.Join("\n", result));
        }

        static void Recursion(int current)
        {
            if (current == girlsCount)
            {
                result.Add(string.Join("-", girls));
                return;
            }

            for (int i = 0; i < shirts; i++)
            {
                if (usedShirts[i])
                {
                    continue;
                }

                usedShirts[i] = true;
                for (int j = 0; j < skirts.Length; j++)
                {
                    if (usedSkirts[j])
                    {
                        continue;
                    }
                    
                    var pair = i.ToString() + j.ToString();
                    if (current == 0)
                    {
                        usedPairs.Add(pair);
                    }
                    else
                    {
                        if (usedPairs.Contains(pair))
                        {
                            continue;
                        }
                    }

                    usedSkirts[j] = true;

                    girls[current] = i.ToString() + skirts[j];
                    Recursion(current + 1);

                    usedSkirts[j] = false;
                }

                usedShirts[i] = false;
            }
        }
    }
}
