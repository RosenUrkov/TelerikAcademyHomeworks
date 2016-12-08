using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingPolynomias
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] firstPolynomia = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondPolynomia = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sumPolynomia = Polynoms(firstPolynomia, secondPolynomia);
            int[] substractPolynomia = Polynoms(firstPolynomia, secondPolynomia, '-');
            int[] productPolynomia = Polynoms(firstPolynomia, secondPolynomia, '*');
            Console.WriteLine(string.Join(" ", sumPolynomia));
            Console.WriteLine(string.Join(" ", substractPolynomia));
            Console.WriteLine(string.Join(" ", productPolynomia));

        }

        static int[] Polynoms(int[] firstOne, int[] secondOne, char polyOperator='+')
        {
            int[] asd = new int[5];
            if (polyOperator == '+')
            {
                int[] sumPolynomia = new int[firstOne.Length];
                for (int index = 0; index < firstOne.Length; index++)
                {
                    sumPolynomia[index] = firstOne[index] + secondOne[index];
                }
                return sumPolynomia;
            }
            else if (polyOperator == '-')
            {
                int[] sumPolynomia = new int[firstOne.Length];
                for (int index = 0; index < firstOne.Length; index++)
                {
                    sumPolynomia[index] = firstOne[index] - secondOne[index];
                }
                return sumPolynomia;
            }
            else if (polyOperator == '*')
            {
                int[] sumPolynomia = new int[firstOne.Length];
                for (int index = 0; index < firstOne.Length; index++)
                {
                    sumPolynomia[index] = firstOne[index] * secondOne[index];
                }
                return sumPolynomia;
            }
            return asd;
        }
    }
}
