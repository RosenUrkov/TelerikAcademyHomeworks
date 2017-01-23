using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberAsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] firstArray = Console.ReadLine().Split(new char[] { ' ', ',', '.' }, StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split(new char[] { ' ', ',', '.' }, StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] arraySum = SumArrays(firstArray, secondArray);
            Console.WriteLine(string.Join(" ", arraySum));


        }

        static int[] SumArrays(int[] firstArray, int[] secondArray)
        {
            int[] biggerSize = (firstArray.Length > secondArray.Length ? firstArray : secondArray);
            int[] smallerSize = (firstArray.Length < secondArray.Length ? firstArray : secondArray);
            int one = 0;
            int[] summedArray = new int[biggerSize.Length + 1];
            for (int index = 0; index < smallerSize.Length; index++)
            {
                summedArray[index] = (firstArray[index] + secondArray[index] + one) % 10;
                one = (firstArray[index] + secondArray[index] + one) / 10;
            }

            for (int index = smallerSize.Length; index < biggerSize.Length; index++)
            {
                summedArray[index] = (biggerSize[index] + one) % 10;
                one = (biggerSize[index] + one) / 10;
            }
            summedArray[summedArray.Length - 1] += one;

            if (summedArray[summedArray.Length - 1] == 0)
            {
                List<int> summedList = summedArray.ToList();
                summedList.RemoveAt(summedList.Count - 1);
                summedArray = summedList.ToArray();

            }
            return summedArray;
        }
    }
}
