using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Businessmen
{  
    public class Program
    {
        public static HashSet<int> used = new HashSet<int>();

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result = result * 2 * (2 * i - 1) / (i + 1);
            }

            Console.WriteLine(result);
        }
    }
}