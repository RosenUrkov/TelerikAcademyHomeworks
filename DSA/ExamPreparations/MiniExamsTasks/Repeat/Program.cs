using System;
using System.Linq;

namespace Repeat
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var numbersCount = numbers.Count;
            numbers.AddRange(numbers);

            var failLinks = new int[numbersCount + 1];
            failLinks[0] = -1;
            failLinks[1] = 0;

            for (int i = 1; i < numbersCount; ++i)
            {
                int j = failLinks[i];
                while (j >= 0 && numbers[i] != numbers[j])
                {
                    j = failLinks[j];
                }

                failLinks[i + 1] = j + 1;
            }

            var result = 0;
            for (int i = 1, j = 0; i < numbers.Count; ++i)
            {
                while (j >= 0 && numbers[i] != numbers[j])
                {
                    j = failLinks[j];
                }

                ++j;
                if (j == numbersCount)
                {
                    result = i - j + 1;
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers.Take(result)));
        }
    }
}