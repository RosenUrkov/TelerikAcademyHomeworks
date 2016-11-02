using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int Factorial(int num)
    {
        if (num == 0)
        {
            return 1;
        }

        return num * Factorial(num - 1);
    }
    
    static void Main(string[] args)
    {
        int num = 5;
        Console.WriteLine(Factorial(num));
        
    }
}

