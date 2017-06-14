using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Framework.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Academy.Core.Providers
{
    public class CommandParser : IParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            return this.commandFactory.GetCommand(commandName);
        }
        
        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            return commandParts;
        }
    }
}
