using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string c = Console.ReadLine();
            string d = Console.ReadLine();
            if(d=="")
            {
                d = "(no fax)";
            }
            string e = Console.ReadLine();
            string f = Console.ReadLine();
            string g = Console.ReadLine();
            string h = Console.ReadLine();
            string i = Console.ReadLine();
            Console.WriteLine("{0}\r\nAddress: {1}\r\nTel. {2}\r\nFax: {3}\r\nWeb site: {4}\r\nManager: {5} {6} (age: {7}, tel. {8})",a,b,c,d,e,f,g,h,i);

        }
    }
}
