using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDictionary
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            myDictionary.Add(".NET", "platform for applications from Microsoft");
            myDictionary.Add("CLR", "managed execution environment for .NET");
            myDictionary.Add("namespace", "hierarchical organization of classes");

            string text = Console.ReadLine();
            Console.WriteLine(myDictionary[text]);

            Main();
        }
    }
}
