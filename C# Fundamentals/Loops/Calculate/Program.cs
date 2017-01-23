using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            double X = double.Parse(Console.ReadLine());
            double sum = 1;
            double factorial = 1;
            for (int i = 1; i <= N; i++)
            {
                factorial *= i;
                sum += ((factorial) / (Math.Pow(X, i)));
            }
            Console.WriteLine("{0:f5}",sum);
        }
    }
}
