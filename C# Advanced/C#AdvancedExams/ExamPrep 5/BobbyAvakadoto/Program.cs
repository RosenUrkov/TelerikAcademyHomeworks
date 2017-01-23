using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobi_Avokadoto
{
    class Program
    {
        static void Main(string[] args)
        {
            uint head = uint.Parse(Console.ReadLine());
            int combsNumber = int.Parse(Console.ReadLine());
            uint currentComb = 0;
            uint bestComb = 0;
            int currentCounter = 0;
            int maxOneBits = -1;
            int shifter;



            for (int i = 0; i < combsNumber; i++)
            {
                currentComb = uint.Parse(Console.ReadLine());
                //string binary = Convert.ToString(currentComb, 2).PadLeft(32, '0');
                if ((head & currentComb) == 0)
                {

                    int oneBitsCount = 0;
                    for (int position = 0; position < 32; position++)
                    {
                        if ((currentComb >> position & 1) == 1)
                        {
                            oneBitsCount++;
                        }
                    }
                    if (oneBitsCount > maxOneBits)
                    {
                        maxOneBits = oneBitsCount;
                        bestComb = currentComb;
                    }

                }
            }
            Console.WriteLine(bestComb);
        }
    }
}
