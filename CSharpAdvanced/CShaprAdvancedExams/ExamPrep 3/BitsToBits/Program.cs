using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsToBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            string result = string.Empty;
            for (int i = 0; i < numberOfNumbers; i++)
            {
                result += Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(30, '0');
            }

            int bestZeros = 0;
            int bestOnes = 0;
            int currentZeros = 0;
            int currentOnes = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '0')
                {
                    if (currentOnes > bestOnes)
                    {
                        bestOnes = currentOnes;                        
                    }
                    currentOnes = 0;
                    currentZeros++;
                }
                if (result[i] == '1')
                {
                    if (currentZeros > bestZeros)
                    {
                        bestZeros = currentZeros;                        
                    }
                    currentZeros = 0;
                    currentOnes++;
                }
            }

            if (currentOnes > bestOnes)
            {
                bestOnes = currentOnes;
            }
            if (currentZeros > bestZeros)
            {
                bestZeros = currentZeros;
            }
           // Console.WriteLine(result);
            Console.WriteLine(bestZeros);
            Console.WriteLine(bestOnes);
        }
    }
}
