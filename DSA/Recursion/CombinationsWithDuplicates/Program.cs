using System;

namespace CombinationsWithDuplicates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberSet = int.Parse(Console.ReadLine());
            int groupLength = int.Parse(Console.ReadLine());

            CombinationsWithDuplicates(numberSet, groupLength, 1, "");
        }

        private static void CombinationsWithDuplicates(int numberSet, int groupLength, int currentNumber, string output)
        {
            groupLength--;
            if (groupLength < 0)
            {
                Console.WriteLine(output);
                return;
            }

            for (int i = currentNumber; i <= numberSet; i++)
            {
                CombinationsWithDuplicates(numberSet, groupLength, i, output + i);
            }
        }
    }
}
