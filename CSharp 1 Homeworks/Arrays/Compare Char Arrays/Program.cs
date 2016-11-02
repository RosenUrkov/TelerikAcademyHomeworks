using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstArray = Console.ReadLine();
            string secondArray = Console.ReadLine();
            bool areEqual = true;
            bool firstBigger = true;

            for (int i = 0; i < Math.Min(firstArray.Length,secondArray.Length); i++)
            {
                if(firstArray[i]!=secondArray[i])
                {
                    if((firstArray[i]-secondArray[i])>0)
                    {
                        firstBigger = false;
                    }
                    areEqual = false;
                    break;
                }


            }
            if (areEqual)
            {
                if (firstArray.Length == secondArray.Length)
                {
                    Console.WriteLine("=");
                }
                else
                {


                    Console.WriteLine((firstArray.Length > secondArray.Length ? ">" : "<"));
                }
            }
            else
            {
                Console.WriteLine(firstBigger ? "<" : ">");
            }

        }
    }
}
