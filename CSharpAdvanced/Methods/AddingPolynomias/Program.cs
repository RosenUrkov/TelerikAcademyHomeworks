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
            int[] sumPolynomia = SumPolynoms(firstPolynomia, secondPolynomia);
            Console.WriteLine(string.Join(" ", sumPolynomia));

        }

        static int[] SumPolynoms(int[] firstOne, int[] secondOne)
        {
            int[] sumPolynomia = new int[firstOne.Length];
            for (int index = 0; index < firstOne.Length; index++)
            {
                sumPolynomia[index] = firstOne[index] + secondOne[index];
            }
            return sumPolynomia;
        }
    }
}
