using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speeds
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsNumber = int.Parse(Console.ReadLine());

            bool isFirst = true;
            int maxLenghtOfCars = 0;
            int currentLenghtOfCars = 0;

            int speedOfCar = 0;
            int speedOfTheLastCar = 0;
            int longestGroupSpeed = 0;
            int currentGroupSpeed = 0;
            bool Group = false;

            for (int i = 0; i < carsNumber; i++)
            {
                speedOfCar = int.Parse(Console.ReadLine());
                Group = true;
                if (isFirst)
                {
                    isFirst = false;
                    currentLenghtOfCars = 1;
                    currentGroupSpeed = speedOfCar;
                    speedOfTheLastCar = speedOfCar;
                    



                }
                else if (speedOfCar > speedOfTheLastCar)
                {
                    currentLenghtOfCars++;
                    currentGroupSpeed += speedOfCar;

                }

                else if (speedOfCar <= speedOfTheLastCar)
                {

                    Group = false;
                    if (currentLenghtOfCars > maxLenghtOfCars)
                    {
                        maxLenghtOfCars = currentLenghtOfCars;
                        longestGroupSpeed = currentGroupSpeed;
                    }
                    else if (currentLenghtOfCars == maxLenghtOfCars)
                    {
                        if (currentGroupSpeed > longestGroupSpeed)
                        {
                            longestGroupSpeed = currentGroupSpeed;
                        }
                    }
                    speedOfTheLastCar = speedOfCar;
                    currentLenghtOfCars = 1;
                    currentGroupSpeed = speedOfCar;
                }
                if (Group)
                {
                    Group = false;
                    if (currentLenghtOfCars > maxLenghtOfCars)
                    {
                        maxLenghtOfCars = currentLenghtOfCars;
                        longestGroupSpeed = currentGroupSpeed;
                    }
                    else if (currentLenghtOfCars == maxLenghtOfCars)
                    {
                        if (currentGroupSpeed > longestGroupSpeed)
                        {
                            longestGroupSpeed = currentGroupSpeed;
                        }
                    }
                }





            }
            Console.WriteLine(longestGroupSpeed);


        }
    }
}
