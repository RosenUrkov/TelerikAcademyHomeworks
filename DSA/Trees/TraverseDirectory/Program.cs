using System;
using System.IO;
using System.Linq;

namespace TraverseDirectory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RecursiveFileSystemTraverse("C:\\WINDOWS");
        }

        private static void RecursiveFileSystemTraverse(string path)
        {
            Directory.EnumerateDirectories(path)
                .ToList()
                .ForEach(x=>
                {
                    Directory.EnumerateFiles(path, "*.exe")
                    .ToList()
                    .ForEach(Console.WriteLine);

                    RecursiveFileSystemTraverse(x);
                });
        }
    }
}
