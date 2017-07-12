using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TraverseDirectory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = FileSystemTree.GenerateTree("C:\\WINDOWS");

            tree.PrintFiles();
            Console.WriteLine(tree.GetByteSize());
        }       
    }
}
