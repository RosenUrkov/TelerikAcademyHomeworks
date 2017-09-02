using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Pair
    {
        public Pair(int[] numbers, int result)
        {
            this.Numbers = numbers;
            this.Result = result;
        }

        public int[] Numbers { get; set; }

        public int Result { get; set; }
    }

    class Program
    {
        static int GetHash(int[] arr)
        {
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result = result * 10 + (arr[i] - '0');
            }

            return result;
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = int.Parse(Console.ReadLine());

            bool isReady = true;
            for (int j = 0; j < n; j++)
            {
                if (numbers[j] != j + 1)
                {
                    isReady = false;
                    break;
                }
            }

            if (isReady)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            var used = new HashSet<int>();

            var copy = new int[n];
            Array.Copy(numbers, copy, n);

            var queue = new Queue<Pair>();
            queue.Enqueue(new Pair(copy, 0));
            used.Add(GetHash(copy));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                for (int i = 0; i < n - k + 1; i++)
                {
                    if (current.Numbers[i] == i + 1)
                    {
                        continue;
                    }

                    var array = new int[n];
                    Array.Copy(current.Numbers, array, n);
                    for (int j = 0; j < k / 2; j++)
                    {
                        var temp = array[i + j];
                        array[i + j] = array[i + k - j - 1];
                        array[i + k - j - 1] = temp;
                    }

                    var hash = GetHash(array);
                    if (used.Contains(hash))
                    {
                        continue;
                    }

                    used.Add(hash);

                    isReady = true;
                    for (int j = 0; j < n; j++)
                    {
                        if (array[j] != j + 1)
                        {
                            isReady = false;
                            break;
                        }
                    }

                    if (isReady)
                    {
                        Console.WriteLine(current.Result + 1);
                        Environment.Exit(0);
                    }

                    queue.Enqueue(new Pair(array, current.Result + 1));
                }
            }

            Console.WriteLine(-1);
        }
    }
}
