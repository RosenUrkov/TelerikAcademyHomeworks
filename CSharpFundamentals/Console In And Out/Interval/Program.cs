using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interval
{
    class Program
    {
        static void Main(string[] args)
        {




            long beginingOfInterval = long.Parse(Console.ReadLine());
            long endOfInterval = long.Parse(Console.ReadLine());
            int counter = 0;
            for (long i = beginingOfInterval + 1; i < endOfInterval; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                }

            }
            Console.WriteLine(counter);
        }

    }
}
