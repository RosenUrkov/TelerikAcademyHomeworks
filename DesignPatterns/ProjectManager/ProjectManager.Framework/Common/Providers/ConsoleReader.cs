using System;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Common.Providers
{
    public class ConsoleReader : IReader
    {     
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
