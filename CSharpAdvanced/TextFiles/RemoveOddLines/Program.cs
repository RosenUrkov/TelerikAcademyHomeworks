using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RemoveOddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\input.txt";
            RemoveOddLines(path);
        }

        static void RemoveOddLines(string path)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine().Trim());
                }
            }

            using (var writer = new StreamWriter(path))
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    if ((i & 1) == 0)
                    {
                        writer.WriteLine(lines[i]);
                    }
//fasgagasfas
//dsadadasdasddas
//safasfsafasfasfafa
//fsafsafsafasfas
//fasfsafasfasfsafsafsafa


                }
            }
        }
    }
}
