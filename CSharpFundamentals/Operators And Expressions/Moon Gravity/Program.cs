using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            float weight = float.Parse(Console.ReadLine());
            float weightInMoon = weight * 0.17f;
            
            Console.WriteLine("{0:f3}",weightInMoon);
        }
    }
}
