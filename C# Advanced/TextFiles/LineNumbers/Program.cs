using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @"..\..\Program.cs";
            EnumerateTextLines(startPath);
        }

        //static StringBuilder ReadFile(string path)
        //{
        //    StringBuilder text = new StringBuilder();
        //    var reader = new StreamReader(path);
        //    using (reader)
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            text.AppendLine(reader.ReadLine());
        //        }
        //    }
        //    return text;
        //}

        static void EnumerateTextLines(string path)
        {
            int counter = 0;
            using (var reader = new StreamReader(path))
            {
                using (var writer = new StreamWriter(@"..\..\enumeredFile.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        writer.WriteLine("{0}. {1}", counter, reader.ReadLine());
                        counter++;
                    }
                }
            }
        }
    }
}
