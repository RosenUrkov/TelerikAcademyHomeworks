using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int__Double__String
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            object variable;
            if(type=="integer")
            {
                variable = int.Parse(Console.ReadLine());
                Console.WriteLine((int)variable+1);

            }
            else if (type == "real")
            {
                variable = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", ((double)variable+1));

            }
            else if (type == "text")
            {
                variable = Console.ReadLine();
                Console.WriteLine("{0}*",variable);

            }
        }
    }
}
