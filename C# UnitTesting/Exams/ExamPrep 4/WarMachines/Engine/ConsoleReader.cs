using System;
using WarMachines.Interfaces;

namespace WarMachines.Engine
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
