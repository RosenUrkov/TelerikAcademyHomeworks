using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStringByLength
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringList = new List<string>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                stringList.Add(Console.ReadLine());
            }

            SortStrings(stringList);
            Console.WriteLine(string.Join(" ",stringList));
        }

        static void SortStrings(List<string> array)
        {            
            for (int j = 0; j < array.Count; j++)
            {
                for (int i = 0; i < array.Count - 1-j; i++)
                {
                    if (array[i].Length > array[i + 1].Length)
                    {
                        string temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
    }
}
