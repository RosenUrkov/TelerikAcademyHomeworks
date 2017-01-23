using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(string.Join(" < ", CollectNumbers()));
            }
            catch (Exception)
            {

                Console.WriteLine("Exception");
            }
        }

        static List<int> CollectNumbers()
        {
            List<int> result = new List<int>();
            result.Add(1);
            result.Add(100);


            result.InsertRange(1, GetNumbers());

            for (int i = 0; i < result.Count - 1; i++)
            {
                if (result[i] >= result[i + 1])
                {
                    throw new ArgumentException();
                }
            }

            return result;

        }

        static List<int> GetNumbers()
        {
            var numbers = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            return numbers;
        }
    }
}
