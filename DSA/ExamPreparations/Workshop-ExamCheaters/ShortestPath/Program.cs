using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Program
    {
        static List<string> result = new List<string>();
        static char[] directions = new char[] { 'L', 'R', 'S' };
        static char[] path;

        static void Main(string[] args)
        {
            path = Console.ReadLine().ToCharArray();
            Recursion();

            Console.WriteLine(result.Count);
            Console.WriteLine(string.Join("\n", result));
        }

        static void Recursion()
        {
            var starIndex = -1;
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == '*')
                {
                    starIndex = i;
                    break;
                }
            }

            if (starIndex == -1)
            {
                result.Add(string.Join("", path));
                return;
            }

            for (int i = 0; i < directions.Length; i++)
            {
                path[starIndex] = directions[i];
                Recursion();
            }

            path[starIndex] = '*';
        }
    }
}
