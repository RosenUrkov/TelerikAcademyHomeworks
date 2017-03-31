using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int size = int.Parse(Console.ReadLine());
                char symbol = (char)Console.Read();

                // print wings
                for (int i = 0; i < (size / 2)-1; i++)
                {
                    Console.WriteLine("{2}{0}{1}{0}{2}", new string(symbol, size - i), new string(' ', size), new string(' ', i));
                }

                // print ears
                Console.WriteLine("{1}{0}{1}{2} {2}{1}{0}{1}", new string(symbol, size / 2 + 2), new string(' ', size / 2 - 1), symbol);

                // print torso
                for (int i = 0; i < size / 3; i++)
                {
                    Console.WriteLine("{1}{0}{1}", new string(symbol, size * 2 + 1), new string(' ', size / 2));
                }

                // print tail
                for (int i = 1; i <= size / 2; i++)
                {
                    Console.WriteLine("{1}{0}{1}", new string(symbol, size - i * 2), new string(' ', size + i));
                }
                Console.WriteLine("---------------------------------------------------------------------");
            }

        }
    }
}
