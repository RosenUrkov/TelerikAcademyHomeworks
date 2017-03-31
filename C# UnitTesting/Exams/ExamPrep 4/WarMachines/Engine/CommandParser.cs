using System;
using System.Collections.Generic;
using WarMachines.Interfaces;

namespace WarMachines.Engine
{
    internal class CommandParser:ICommandParser
    {
        protected IReader reader;

        public CommandParser(IReader reader)
        {
            this.reader = reader;     
        }

        public CommandParser():this(new ConsoleReader())
        {
            
        }

        public IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.reader.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);

                currentLine = this.reader.ReadLine();
            }

            return commands;
        }
    }
}
