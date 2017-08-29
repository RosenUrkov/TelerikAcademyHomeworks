using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TheRingsOfTheAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n + 1];

            var factorials = new BigInteger[n + 1];
            factorials[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                var num = int.Parse(Console.ReadLine());

                arr[num]++;
                factorials[i] = i * factorials[i - 1];
            }


            BigInteger result = 1;
            foreach (var val in arr)
            {
                result *= factorials[val];
            }

            Console.WriteLine(result);
        }
    }
}
