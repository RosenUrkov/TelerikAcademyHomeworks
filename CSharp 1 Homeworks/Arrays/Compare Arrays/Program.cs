using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] firstArray = new int[number];
            int[] secondArray = new int[number];
            bool equal = true;

            for(int i = 0; i < number; i++)
            {
                firstArray[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < number; i++)
            {
                secondArray[i] = int.Parse(Console.ReadLine());
                if(secondArray[i]!=firstArray[i])
                {
                    equal = false;
                }
            }
            if(equal)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }
            
        }
    }
}
