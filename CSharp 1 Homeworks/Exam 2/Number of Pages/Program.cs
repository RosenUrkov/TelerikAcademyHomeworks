using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_of_Pages
{
    class Program
    {
        static void Main(string[] args)
        {
            int digits = int.Parse(Console.ReadLine());

            int page = 0;
            for (page = 1; digits!=0; page++)
            {
                digits -= page.ToString().Length;

            }
            Console.WriteLine(--page);

               

        }
    }
}
