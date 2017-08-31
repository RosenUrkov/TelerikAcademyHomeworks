using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABoxFullOfBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            var moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var startAndEnd = Console.ReadLine().Split(' ');
            var start = int.Parse(startAndEnd[0]);
            var end = int.Parse(startAndEnd[1]) + 1;

            var result = new bool[end];
            for (int i = 0; i < moves.Length; i++)
            {
                result[moves[i]] = true;
            }

            var mvs = new List<int>();
            for (int i = 0; i < end; i++)
            {
                if (result[i])
                {
                    mvs.Add(i);
                    continue;
                }
                if (mvs.Any(x => !result[i - x]))
                {
                    result[i] = true;
                }
            }

            var sum = 0;
            for (int i = start; i < end; i++)
            {
                if (result[i])
                {
                    sum++;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
