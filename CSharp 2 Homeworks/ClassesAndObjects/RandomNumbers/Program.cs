using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random fuck = new Random();
            for (int i = 0; i < 10; i++)
            {
                int random = fuck.Next(100, 201);
                Console.WriteLine(random);
            }
        }
    }
}
