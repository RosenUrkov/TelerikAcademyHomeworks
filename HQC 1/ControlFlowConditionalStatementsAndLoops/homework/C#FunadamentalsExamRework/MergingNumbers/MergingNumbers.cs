namespace MergingNumbers
{
    using System;
    using System.Collections.Generic;

    public class MergingNumbers
    {
        public static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            List<int> mergedNumbers = new List<int>();
            List<int> sumedNumbers = new List<int>();

            bool isFirst = true;

            int added = 0;
            string merged = string.Empty;

            int firstDigit = 0;
            int secondDigit = 0;
            
            for (int i = 0; i < numbersCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (isFirst)
                {
                    isFirst = false;
                    firstDigit = currentNumber % 10;
                    added += currentNumber;
                }
                else
                {
                    added += currentNumber;
                    sumedNumbers.Add(added);
                    added = currentNumber;                    
                    
                    secondDigit = currentNumber / 10;

                    merged += firstDigit;
                    merged += secondDigit;
                    mergedNumbers.Add(int.Parse(merged));
                    merged = string.Empty;

                    firstDigit = currentNumber % 10;
                }
            }

            Console.WriteLine(string.Join(" ", mergedNumbers));
            Console.WriteLine(string.Join(" ", sumedNumbers));
        }
    }
}
