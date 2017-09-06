using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredBeads
{
    class Program
    {
        static List<string> results = new List<string>();
        static int[] numbers;
        static int length = 0;
        static char[] current;
        static char[] possibles = new char[] { 'B', 'G', 'R' };
        static int target = -1;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            target = int.Parse(Console.ReadLine());

            var temp = numbers[2];
            numbers[2] = numbers[0];
            numbers[0] = temp;

            for (int i = 0; i < numbers.Length; i++)
            {
                length += numbers[i];
            }

            current = new char[length];

            Recursion(0, -1);

            Console.WriteLine(string.Join("\n", results));
        }

        static void Recursion(int index, int perv)
        {
            if (index == length)
            {
                if (results.Count == target)
                {
                    Console.WriteLine(string.Join("", current));
                    Environment.Exit(0);
                }

                results.Add(string.Join("", current));
                return;
            }

            if (perv == 0)
            {
                if (numbers[1] > 0)
                {
                    numbers[1]--;
                    current[index] = possibles[1];
                    Recursion(index + 1, 1);
                    numbers[1]++;
                }

                if (numbers[2] > 0)
                {
                    numbers[2]--;
                    current[index] = possibles[2];
                    Recursion(index + 1, 2);
                    numbers[2]++;
                }

                return;
            }
            else if (perv == 1)
            {
                if (numbers[0] > 0)
                {
                    numbers[0]--;
                    current[index] = possibles[0];
                    Recursion(index + 1, 0);
                    numbers[0]++;
                }

                if (numbers[2] > 0)
                {
                    numbers[2]--;
                    current[index] = possibles[2];
                    Recursion(index + 1, 2);
                    numbers[2]++;
                }

                return;
            }
            else if (perv == 2)
            {
                if (numbers[0] > 0)
                {
                    numbers[0]--;
                    current[index] = possibles[0];
                    Recursion(index + 1, 0);
                    numbers[0]++;
                }

                if (numbers[1] > 0)
                {
                    numbers[1]--;
                    current[index] = possibles[1];
                    Recursion(index + 1, 1);
                    numbers[1]++;
                }

                return;
            }

            if (numbers[0] > 0)
            {
                numbers[0]--;
                current[index] = possibles[0];
                Recursion(index + 1, 0);
                numbers[0]++;
            }

            if (numbers[1] > 0)
            {
                numbers[1]--;
                current[index] = possibles[1];
                Recursion(index + 1, 1);
                numbers[1]++;

            }

            if (numbers[2] > 0)
            {
                numbers[2]--;
                current[index] = possibles[2];
                Recursion(index + 1, 2);
                numbers[2]++;
            }
        }
    }
}
