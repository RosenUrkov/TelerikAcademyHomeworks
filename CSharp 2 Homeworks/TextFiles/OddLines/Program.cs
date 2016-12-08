using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\text.txt";
            try
            {
                Console.WriteLine((CreateFile(path)));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine();
                //Console.WriteLine(exc.Source);
                Console.WriteLine();
                Console.WriteLine(exc.StackTrace);

            }
        }

        static string CreateFile(string path)
        {
            var stream = File.Create(path);
            WriteInFile(stream);
            string oddLines = OddLines(stream);
            stream.Close();
            return oddLines;
        }

        static void WriteInFile(FileStream stream)
        {
            var writer = new StreamWriter(stream);

            Console.WriteLine("Enter the number of lines:");
            int number = int.Parse(Console.ReadLine());
            writer.AutoFlush = true;
            for (int i = 0; i < number; i++)
            {
                writer.WriteLine(Console.ReadLine());

            }

        }


        static string OddLines(FileStream stream)
        {
            StringBuilder oddLines = new StringBuilder();

            var reader = new StreamReader(stream);
            stream.Position = 0;
            //reader.DiscardBufferedData();
            int counter = 0;


            while (!reader.EndOfStream)
            {


                if ((counter & 1) == 1)
                {
                    oddLines.AppendLine(reader.ReadLine());
                }
                else
                {
                    reader.ReadLine();
                }

                counter++;
            }

            return oddLines.ToString();

        }
    }
}
