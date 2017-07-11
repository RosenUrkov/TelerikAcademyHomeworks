using System;
using System.Collections.Generic;

namespace NumbersOccureance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dictionary = new Dictionary<double, int>();

            var list = new List<double>(){ 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            list.ForEach(x =>
            {
                if (dictionary.ContainsKey(x))
                {
                    dictionary[x]++;
                    return;
                }

                dictionary.Add(x, 1);
            });

            Console.WriteLine(string.Join(" ", dictionary));
        }
    }
}
