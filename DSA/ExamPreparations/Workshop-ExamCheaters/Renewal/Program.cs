using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewal
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine();
                for (int j = 0; j < current.Length; j++)
                {
                    matrix[i, j] = current[j] - '0';
                }
            }

            var build = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine();
                for (int j = 0; j < current.Length; j++)
                {
                    build[i, j] = char.IsUpper(current[j]) ? current[j] - 'A' : current[j] - 'a' + 26;
                }
            }

            var destroy = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine();
                for (int j = 0; j < current.Length; j++)
                {
                    destroy[i, j] = char.IsUpper(current[j]) ? current[j] - 'A' : current[j] - 'a' + 26;
                }
            }

            long cost = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        //matrix[j, i] = 0;
                        cost += destroy[i, j];
                    }
                }
            }
        }
    }
}
