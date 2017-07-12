using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace TraverseDirectory
{
    public class FileSystemTree
    {
        public FileSystemTree(Folder root)
        {
            this.Root = root;
        }

        public Folder Root { get; private set; }

        public void PrintFiles()
        {
            this.TraverseFiles(this.Root, x => Console.WriteLine($"Name: {x.Name} Size: {x.Size} bytes"));
        }      
        
        public BigInteger GetByteSize()
        {
            return this.GetFolderByteSize(this.Root);
        }

        public BigInteger GetFolderByteSize(Folder folder)
        {
            BigInteger size = 0;
            this.TraverseFiles(folder, x => size += x.Size);
            return size;
        }

        public static FileSystemTree GenerateTree(string fsPath)
        {
            var root = new Folder(fsPath);
            GenerateTree(fsPath, root);

            return new FileSystemTree(root);
        }       

        private static void GenerateTree(string fsPath, Folder currentFolder)
        {
            Directory.EnumerateFiles(fsPath, "*.exe", SearchOption.TopDirectoryOnly)
                .Select(x => new FileInfo(x))
                .Select(x => new File(x.Name, x.Length))
                .ToList()
                .ForEach(x => currentFolder.Files.Add(x));

            Directory.EnumerateDirectories(fsPath)
                .Select(x => new Folder(x))
                .ToList()
                .ForEach(x =>
                {
                    currentFolder.ChildFolders.Add(x);

                    try
                    {
                        GenerateTree(x.Name, x);
                    }
                    catch
                    {
                        return;
                    }
                });
        }

        private void TraverseFiles(Folder folder, Action<File> action)
        {
            folder.ChildFolders.ForEach(x => TraverseFiles(x, action));
            folder.Files.ForEach(action);
        }
    }
}
