using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] arrayOfInts = new int[number];
            for (int i = 0; i < arrayOfInts.Length; i++)
            {
                Console.WriteLine(i*5);
            }
        }
    }
}
