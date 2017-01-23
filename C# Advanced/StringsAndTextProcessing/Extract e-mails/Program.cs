using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Extract_e_mails
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string pattern = @"([^ ]+)@(\w+).(\w+)\S*";

            Regex validation = new Regex(pattern);
            Match eMailMatch = validation.Match(email);

            Console.WriteLine(validation.IsMatch(email));
            Console.WriteLine(eMailMatch.Groups[0]);
        }
    }
}
