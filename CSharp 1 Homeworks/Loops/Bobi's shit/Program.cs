using System;
using System.Linq;
using System.Collections.Generic;


namespace FindSumInArray
{
    class FindSumInArray
    {
        static void Main()
        {
            var numbersArr = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var membersOfSum = new List<int>();
            int sumToSearch = int.Parse(Console.ReadLine());


            bool sumExists = false;
            for (int i = 0; i < numbersArr.Length; i++)
            {
                long currSum = 0;
                for (int k = i; k < numbersArr.Length; k++)
                {
                    currSum += numbersArr[k];
                    if (currSum == sumToSearch)
                    {
                        for (int j = i; j <= k; j++)
                        {
                            membersOfSum.Add(numbersArr[j]);
                        }
                        Console.WriteLine(string.Join(", ",membersOfSum));
                        membersOfSum.Clear();
                        sumExists = true;
                        continue;
                    }

                }

            }

            if (!sumExists)
            {
                Console.WriteLine("no such sequence that equal desired sum exists");
            }


        }
    }
}