using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalkoKote
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char symbol = (char)Console.Read();
            int keyNumber = (size / 4) + 1;
            //head
            Console.WriteLine("{0}{1}{2}{1}", new string(' ', 1), symbol, new string(' ', keyNumber - 2));
            for (int i = 0; i < (keyNumber - 2); i++)
            {
                Console.Write(" {0}", new string(symbol, keyNumber));
                Console.WriteLine();
            }
            //neck
            for (int i = 0; i < (keyNumber - 2); i++)
            {
                Console.Write("{0}{1}", new string(' ', 2), new string(symbol, keyNumber - 2));
                Console.WriteLine();
            }
            //shoulders
            for (int i = 0; i < (keyNumber - 2); i++)
            {
                Console.Write(" {0}", new string(symbol, keyNumber));
                Console.WriteLine();
            }
            Console.Write(" {0}", new string(symbol, keyNumber));
            Console.Write("{0}", new string(' ', 3));
            Console.WriteLine("{0}", new string(symbol, keyNumber - 1));
            //body
            for (int i = 0; i < (keyNumber); i++)
            {
                Console.Write("{0}", new string(symbol, keyNumber + 2));
                Console.Write("{0}", new string(' ', 2));
                Console.WriteLine(symbol);
            }
            //legs
            Console.Write("{0}", new string(symbol, keyNumber + 2));
            Console.Write("{0}", new string(' ', 1));
            Console.WriteLine("{0}", new string(symbol, 2));
            Console.Write(" {0}", new string(symbol, keyNumber + 3));



        }
    }
}
