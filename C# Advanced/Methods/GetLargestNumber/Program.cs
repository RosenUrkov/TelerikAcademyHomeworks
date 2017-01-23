using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLargestNumber
{
   
    class Program
    {
        static int count = 0;        

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int biggestNumber = GetMax(numbers);
            Console.WriteLine(biggestNumber);            

        }

        //static List<int> GetNumbers(List<int> listOfNumbers)
        //{            
        //    if (count==3)
        //    {
        //        return listOfNumbers;
        //    }            
        //    count++;
        //    int number = int.Parse(Console.ReadLine());            
        //    listOfNumbers.Add(number);
        //    listOfNumbers = GetNumbers(listOfNumbers);
        //    return listOfNumbers;
        //}

        static int GetMax(List<int> numbersList)
        {
            int maxNumber = int.MinValue;
            for (int number = 0; number < numbersList.Count; number++)
            {
                if(numbersList[number]>maxNumber)
                {
                    maxNumber = numbersList[number];
                }
            }
            return maxNumber;
        }
    }
}
