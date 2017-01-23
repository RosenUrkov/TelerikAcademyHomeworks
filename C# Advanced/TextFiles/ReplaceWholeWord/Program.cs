using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceSubStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\input.txt";
            ReplaceSubstrings(path);
        }

        static void ReplaceSubstrings(string path)
        {
            string content = string.Empty;
            using (var reader = new StreamReader(path))
            {
                content = string.Join("", reader.ReadLine().Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)).Replace("start", "finish");
            }
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(content);
            }
        }
    }
}
