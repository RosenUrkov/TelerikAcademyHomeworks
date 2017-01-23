using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapYear
{

    class Program
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            bool isLeap = DateTime.IsLeapYear(year);
            Console.WriteLine(isLeap ? "Leap" : "Common");
        }
    }
}
