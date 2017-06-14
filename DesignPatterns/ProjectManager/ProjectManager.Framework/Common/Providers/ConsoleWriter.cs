using ProjectManager.Common.Contracts;
using System;

namespace ProjectManager.Common.Providers
{
    public class ConsoleWriter : IWriter
    {   
        public void Write(object value)
        {
            Console.Write(value);
        }

        public void WriteLine(object value)
        {
            Console.WriteLine(value);
        }
    }
}
