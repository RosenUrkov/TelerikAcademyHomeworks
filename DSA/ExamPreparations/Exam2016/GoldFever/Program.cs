using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            long result = 0;
            var maxElement = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if(arr[i] > maxElement)
                {
                    maxElement = arr[i];
                }

                result += maxElement - arr[i];
            }

            Console.WriteLine(result);
        }
    }
}
