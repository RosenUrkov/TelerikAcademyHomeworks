using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            var input = Console.ReadLine()
                .Split(' ')
                .GroupBy(x => x[0])
                .OrderBy(x => x.Key)
                .ToArray();

            var result = new List<string>();
            result.AddRange(input[1]);
            result.AddRange(input[0]);
            result.AddRange(input[2]);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
