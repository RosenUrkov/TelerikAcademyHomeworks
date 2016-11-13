using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_3D
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            Console.WriteLine(new string(':', number));

            for (int i = 0; i < number - 2; i++)
            {
                Console.WriteLine(":{0}:{1}:", new string(' ', number - 2), new string('|', i));
            }

            Console.WriteLine("{0}{1}:", new string(':', number), new string('|', number - 2));

            for (int i = number - 2; i > 0; i--)
            {
                Console.WriteLine("{2}:{0}:{1}:", new string('-', number - 2), new string('|', i - 1), new string(' ', number - 1 - i));
            }

            Console.WriteLine("{0}{1}", new string(' ', number - 1), new string(':', number));


        }
    }
}
