using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            int numbersByte = int.Parse(Console.ReadLine());
            
            Console.WriteLine((number&(1<<numbersByte))>>numbersByte);

        }
    }
}
