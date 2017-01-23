using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conductors
{
    class Program
    {
        static void Main(string[] args)
        {
            uint perforator = uint.Parse(Console.ReadLine());
            string bitwisePerforator = Convert.ToString(perforator, 2);
            uint mask = (uint)((1 << bitwisePerforator.Length) - 1);
            int numberOfTickets = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTickets; i++)
            {
                uint ticket = uint.Parse(Console.ReadLine());
                for (int j = 0; j < 32 - bitwisePerforator.Length; j++)
                {
                    if ((ticket & (mask << j)) == (perforator << j))
                    {
                        ticket = (ticket & (~(perforator << j)));
                    }
                    //Console.WriteLine(Convert.ToString(ticket,2).PadLeft(32,'0'));
                    //Console.WriteLine(Convert.ToString(perforator<<j,2).PadLeft(32,'0'));
                    //Console.WriteLine(Convert.ToString(((~perforator)<<j),2).PadLeft(32,'0'));
                    //Console.WriteLine("-------------------");

                }
                Console.WriteLine(ticket);
            }
        }
    }
}
