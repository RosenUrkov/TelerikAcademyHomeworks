using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            uint originalPerforator = uint.Parse(Console.ReadLine());

            uint numberOfTickets = uint.Parse(Console.ReadLine());
            int size = Convert.ToString(originalPerforator, 2).Length;
            int sizeOfPerforator = ((1 << (size)) - 1);
            int positionOfPerforator;
            uint perforator;


            for (int i = 0; i < numberOfTickets; i++)
            {
                uint currentTicket = uint.Parse(Console.ReadLine());
                uint perforatedTicket = currentTicket;



                int counter = 0;
                while (true)
                {

                    perforator = (originalPerforator << counter);
                    positionOfPerforator = (sizeOfPerforator << counter);
                    //Console.WriteLine(Convert.ToString(perforator,2));
                    //Console.WriteLine(Convert.ToString(perforatedTicket, 2));
                    //Console.WriteLine("---------------------------------------------");
                    if ((perforatedTicket & positionOfPerforator) == perforator)
                    {


                        perforatedTicket = (perforatedTicket & (~perforator));
                    }
                    if (((perforator >> 31) & 1) == 1)
                    {
                        break;
                    }
                    counter++;



                }
                Console.WriteLine(perforatedTicket);
            }

        }
    }
}
