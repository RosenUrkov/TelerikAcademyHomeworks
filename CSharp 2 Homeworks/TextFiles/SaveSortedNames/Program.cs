using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveSortedNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\input.txt";
            SortNames(path);
        }

        static void SortNames(string path)
        {
            var names = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    names.Add(reader.ReadLine().Trim());
                }
            }

            names.Sort();

            using (var writer = new StreamWriter(@"..\..\output.txt"))
            {
                for (int i = 0; i < names.Count; i++)
                {
                    writer.WriteLine(names[i]);
                }
            }
        }
    }
}
