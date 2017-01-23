using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            int studets = int.Parse(Console.ReadLine());
            int paperSheetsPerStudent = int.Parse(Console.ReadLine());
            double priceOfRealm = double.Parse(Console.ReadLine());

            double realmsNeeded = 0;
            double totalMoneyNeeded = 0;

            realmsNeeded = (studets * paperSheetsPerStudent) / (double)400;
            totalMoneyNeeded = realmsNeeded * priceOfRealm;

            Console.WriteLine("{0:f3}", totalMoneyNeeded);


        }
    }
}
