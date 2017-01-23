using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            if(number<=0||number>9)
            {
                Console.WriteLine("invalid score");
            }

            else if(number>=1&&number<=3)
            {
                number *= 10;
                Console.WriteLine(number);
            }
            else if (number >= 4 && number <= 6)
            {
                number *= 100;
                Console.WriteLine(number);
            }
            else if (number >= 7 && number <= 9)
            {
                number *= 1000;
                Console.WriteLine(number);
            }
            
        }
    }
}
