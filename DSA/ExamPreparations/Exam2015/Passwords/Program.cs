using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    public class Program
    {
        public static void Main()
        {
            int digitsCount = int.Parse(Console.ReadLine());

            var directions = Console.ReadLine();
            int targetCombination = int.Parse(Console.ReadLine());
            target = targetCombination;

            var current = new int[digitsCount];

            for (int i = 0; i < 10; i++)
            {
                current[0] = i;
                Solve(1, current, directions);
            }
        }

        static int counter = 0;

        static int target;

        static List<string> results = new List<string>();

        public static void Solve(int index, int[] current, string directions)
        {
            if (index >= current.Length)
            {
                counter++;
                if (counter == target)
                {
                    Console.WriteLine(string.Join("", current));
                    Environment.Exit(0);
                }

                return;
            }

            var direction = directions[index - 1];
            var prev = current[index - 1];

            if (direction == '=')
            {
                current[index] = prev;
                Solve(index + 1, current, directions);
            }
            else
            {

                for (int i = 0; i < 10; i++)
                {
                    if (direction == '<')
                    {
                        if (i != 0 && i < prev)
                        {
                            current[index] = i;
                            Solve(index + 1, current, directions);
                        }
                        else if (i != 0 && prev == 0)
                        {
                            current[index] = i;
                            Solve(index + 1, current, directions);
                        }
                    }
                    else if (direction == '>')
                    {
                        if (prev != 0 && i > prev)
                        {
                            current[index] = i;
                            Solve(index + 1, current, directions);
                        }
                        else if (prev != 0 && i == 0)
                        {
                            current[index] = i;
                            Solve(index + 1, current, directions);
                        }
                    }
                }
            }
        }
    }
}