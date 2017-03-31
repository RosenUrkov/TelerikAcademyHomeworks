namespace MagicalNumbers
{
    using System;

    public class MagicalNumbers
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int firstDigit = number % 10;
            int secondDigit = number / 10;
            int thirdDigit = secondDigit / 10;
            secondDigit = secondDigit % 10;

            double result;
            if ((secondDigit % 2) == 1)
            {
                result = (thirdDigit * secondDigit) / (double)firstDigit;
                Console.WriteLine("{0:f2}", result);
            }
            else
            {
                result = (thirdDigit + secondDigit) * (double)firstDigit;
                Console.WriteLine("{0:f2}", result);
            }
        }
    }
}
