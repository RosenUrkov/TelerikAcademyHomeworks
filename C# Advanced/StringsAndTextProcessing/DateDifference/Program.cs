using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DateDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            int days = 0;
            days+= (secondDate.Year-firstDate.Year)*365;
            days += (secondDate.Month - firstDate.Month) * 30;
            days += secondDate.Day - firstDate.Day;

            Console.WriteLine(days);



        }
    }
}
