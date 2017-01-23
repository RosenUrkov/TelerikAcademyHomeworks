using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthday = new DateTime();
            birthday.ToString("MM.dd.yyyy");
            birthday = DateTime.Parse(Console.ReadLine());
            

            int yearsOld;
            Console.WriteLine(yearsOld = (DateTime.Now.Year - birthday.Year));
            Console.WriteLine(yearsOld + 10);
        }
    }
}
