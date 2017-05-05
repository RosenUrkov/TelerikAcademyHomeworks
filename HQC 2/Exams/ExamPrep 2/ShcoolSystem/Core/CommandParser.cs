namespace SchoolSystem.Core
{
    using SchoolSystem.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandParser : ICommandParser
    {
        public ICommand ParseCommand(string command)
        {
            var commandName = command.Split(' ')[0];
            var assembly = GetType().GetTypeInfo().Assembly;

            var typeInfo = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .FirstOrDefault();

            if (typeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            var currentCommand = Activator.CreateInstance(typeInfo) as ICommand;

            return currentCommand;
        }
    }
}
