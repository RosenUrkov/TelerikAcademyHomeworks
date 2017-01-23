using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadFileContents
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\text.txt";
            try
            {
                Console.WriteLine(CreateFile(path));               
            }
            catch (Exception exc)
            {

                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.StackTrace);
            }
        }

        static string CreateFile(string path)
        {
            var stream = File.Create(path);
            WriteInFile(stream);
            stream.Close();
            return ReadFromFile(path);
                        
        }

        static void WriteInFile(FileStream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(Console.ReadLine());
            }
        }

        static string ReadFromFile(string path)
        {
            string textInFile = File.ReadAllText(path);
            return textInFile;
        }
    }
}
