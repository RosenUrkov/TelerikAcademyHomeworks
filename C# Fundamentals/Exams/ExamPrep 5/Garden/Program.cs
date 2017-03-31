using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] seedPrice = { 0.5, 0.4, 0.25, 0.6, 0.3 };
            int totalArea = 250;
            double totalPrice = 0;
            double beansPrice = 0.4;


            for (int i = 0; i < 5; i++)
            {
                int seeds = int.Parse(Console.ReadLine());
                int area = int.Parse(Console.ReadLine());

                totalPrice += (seeds * seedPrice[i]);
                totalArea -= area;

            }

            int beansSeeds = int.Parse(Console.ReadLine());
            totalPrice += (beansSeeds * beansPrice);

            Console.WriteLine("Total costs: {0:f2}", totalPrice);
            if (totalArea > 0)
            {
                Console.WriteLine("Beans area: {0}", totalArea);
            }
            else if (totalArea < 0)
            {
                Console.WriteLine("Insufficient area");
            }
            else
            {
                Console.WriteLine("No area for beans");
            }
        }
    }
}
