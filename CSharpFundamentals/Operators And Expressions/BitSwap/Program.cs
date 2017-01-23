using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            long firstSwap = long.Parse(Console.ReadLine());
            long secondSwap = long.Parse(Console.ReadLine());
            long swapLenght = long.Parse(Console.ReadLine());
            long firstSwapLimit = firstSwap + swapLenght - 1;
            long secondSwapLimit = secondSwap + swapLenght - 1;
            long swapBitsNumber = firstSwapLimit - firstSwap + 1;
            long bitsNumberAsOnes = (((long)Math.Pow(2, swapBitsNumber))-1);
            long firstBitsPositions = bitsNumberAsOnes << (int)firstSwap;
            long firstBitsMask = ((number & firstBitsPositions) >> (int)firstSwap);
            long secondBitsPositions = bitsNumberAsOnes << (int)secondSwap;
            long secondBitsMask = ((number & secondBitsPositions) >> (int)secondSwap);
            //Console.WriteLine(Convert.ToString(number, 2));
            number = (number & (~firstBitsPositions));
            number = (number & (~secondBitsPositions));
            number = (number | (firstBitsMask << (int)secondSwap));
            number = (number | (secondBitsMask << (int)firstSwap));
            //Console.WriteLine(Convert.ToString(number, 2));
            Console.WriteLine(number);





        }
    }
}
