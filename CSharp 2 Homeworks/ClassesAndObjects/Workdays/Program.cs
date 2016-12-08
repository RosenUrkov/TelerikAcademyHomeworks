using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workdays
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            DateTime date = DateTime.Parse(Console.ReadLine());
            DateTime[] holidays = new DateTime[]
            {
      new DateTime(2016,12,24),
      new DateTime(2016,12,25),
      new DateTime(2017,01,01),
      
           };
            //Console.WriteLine((int)date.DayOfWeek);           
            int counter = 0;
            for (DateTime i = today; i < date; i=i.AddDays(1))
            {
                bool isHoliday = false;
                for (int j = 0; j < holidays.Length; j++)
                {
                    if(i==holidays[j])
                    {
                        isHoliday = true;
                        break;
                    }
                }
                if((int)i.DayOfWeek==6||(int)i.DayOfWeek==0||isHoliday)
                {
                    continue;
                }
                else
                {
                    counter++;
                }
                
            }

            Console.WriteLine(counter);
        }
    }
}
