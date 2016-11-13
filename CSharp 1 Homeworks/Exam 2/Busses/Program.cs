using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busses
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBusses = int.Parse(Console.ReadLine());
            bool isFirst = true;
            int speedOfTheLastCar = 0;
            int speedOfTheCurrentCar = 0;
            int groupsCount = 0;

            for (int i = 0; i < numberOfBusses; i++)
            {
                speedOfTheCurrentCar = int.Parse(Console.ReadLine());
                if (isFirst)
                {
                    isFirst = false;
                    speedOfTheLastCar = speedOfTheCurrentCar;

                }
                else if (speedOfTheCurrentCar <= speedOfTheLastCar)
                {
                    groupsCount++;
                    speedOfTheLastCar = speedOfTheCurrentCar;
                }
                if (i + 1 == numberOfBusses)
                {
                    groupsCount++;
                }


            }
            Console.WriteLine(groupsCount);

        }
    }
}
