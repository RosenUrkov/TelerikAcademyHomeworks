using System;
using System.Collections.Generic;
using System.Linq;

namespace IntNumbersSequence
{
    public class Startup
    {
        public static void Main()
        {
            var list = new List<int>();
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                list.Add(int.Parse(input));
            }

            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Average());
        }
    }
}
