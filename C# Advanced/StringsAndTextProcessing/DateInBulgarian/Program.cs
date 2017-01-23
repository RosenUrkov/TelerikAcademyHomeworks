using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DateInBulgarian
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss",CultureInfo.InvariantCulture);
            DateTime newDate = date;
            newDate= newDate.AddHours(6);
            newDate = newDate.AddMinutes(30);
            Console.WriteLine("{0:ddd.MM.yyy hh:mm:ss}", newDate);
        }
    }
}
