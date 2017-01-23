using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveTasks
{
    class Program
    {
        static void Main()
        {
            int taskNumber = Menu();
            if (taskNumber == 1)
            {
                char[] reverseNumber = ReverseDigits();
                Console.WriteLine(reverseNumber);
            }
            else if (taskNumber == 2)
            {
                int averageNumber = AverageOfSequence();
                Console.WriteLine(averageNumber);
            }
            else if (taskNumber == 3)
            {
                int result = LinearEquation();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Fuck you");
            }

            Main();

        }

        static int Menu()
        {
            int taskNumber = 0;
            Console.WriteLine("Choice whitch task do you wanna solve:");
            Console.WriteLine("If you want to reverse digits of a number press 1.");
            Console.WriteLine("If you want to calculate the average of a sequence of integers press 2.");
            Console.WriteLine("If you want to solve a linear equation press 3.");
            taskNumber = int.Parse(Console.ReadLine());
            return taskNumber;
        }

        static char[] ReverseDigits()
        {

            int number = 0;
            do
            {
                Console.WriteLine("Please enter a positive number ot reverse its digits.");
                number = int.Parse(Console.ReadLine());

            } while (number < 0);

            char[] digitsArray = number.ToString().ToCharArray();
            for (int index = 0; index < digitsArray.Length / 2; index++)
            {
                char temp = digitsArray[index];
                digitsArray[index] = digitsArray[digitsArray.Length - 1 - index];
                digitsArray[digitsArray.Length - 1 - index] = temp;

            }
            return digitsArray;
        }

        static int AverageOfSequence()
        {
            int[] numbers = new int[0];
            do
            {

                Console.WriteLine("Please enter a sequence of numbers.");
                numbers = Console.ReadLine().Split(new char[] { ' ', ',', '.' }, StringSplitOptions
                    .RemoveEmptyEntries).Select(int.Parse).ToArray();
            } while (numbers.Length == 0);

            int average = 0;
            int sum = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                sum += numbers[index];
            }
            average = sum / numbers.Length;
            return average;

        }

        static int LinearEquation()
        {
            int a = 1;
            int x = 1;
            int b = 0;
            do
            {
                Console.WriteLine("Please enter a positive 'a' and 'x'.");
                a = int.Parse(Console.ReadLine());
                x = int.Parse(Console.ReadLine());
            } while (!(a > 0 && x > 0));
            Console.WriteLine("Please enter a 'b'.");
            b = int.Parse(Console.ReadLine());

            return a * x + b;
        }
    }
}
