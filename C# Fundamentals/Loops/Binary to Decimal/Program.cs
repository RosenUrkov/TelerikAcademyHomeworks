using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_to_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            //string binary = Console.ReadLine().PadLeft(32,'0');
            //double sum = 0;
            //int counter = 0;
            //for (int i = 31; i >= 0 ; i--, counter++)
            //{
            //    if(binary[counter]=='1')
            //    {
            //        sum += Math.Pow(2, i);
            //    }
            //}
            //long sum1 = Convert.ToInt64(sum);
            //Console.WriteLine(sum1);


            string binary = Console.ReadLine();
            long decimalValue = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                int currBit = binary[binary.Length - 1 - i] - '0';

                decimalValue += currBit * (long)Math.Pow(2, i);
                
            }         
        }
    }
}
