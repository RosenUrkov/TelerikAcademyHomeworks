using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DatesFromText
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            
            Regex dateValidate = new Regex(@"[0-3]{1}[0-9]{1}\.[0-1]{1}[0-9]{1}\.([0-9]{4})");
            MatchCollection dateCollection = dateValidate.Matches(text);

            string[] array = Regex.Split(text, @"[0-3]{1}[0-9]{1}\.[0-1]{1}[0-9]{1}\.[0-9]{4}");
            string[] left = text.Split(array,StringSplitOptions.RemoveEmptyEntries);

            text = Regex.Replace(text, @"[0-3]{1}[0-9]{1}\.[0-1]{1}[0-9]{1}\.([0-9]{4})", "[$1]");
            Console.WriteLine(text);

            //CultureInfo culture = new CultureInfo("en-Ca");

            //foreach (Match match  in dateCollection)
            //{
            //    Console.WriteLine("{0:dd.MM.yyyy}",match.Groups[0]);
            //}
        }
    }
}
