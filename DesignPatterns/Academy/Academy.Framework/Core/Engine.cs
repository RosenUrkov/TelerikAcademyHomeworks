using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Academy.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;
        
        public Engine(IReader reader, IWriter writer, IParser parser)
        {
            this.reader = reader;
            this.writer = writer;
            this.parser = parser;
        }

        public void Start()
        {
            var builder = new StringBuilder();

            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.Write(builder.ToString());
                        break;
                    }

                    builder.AppendLine(this.ProcessCommand(commandAsString));
                }
                catch (ArgumentOutOfRangeException)
                {
                    builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    builder.AppendLine(ex.Message);
                }
            }
        }

        private string ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            return command.Execute(parameters);
        }
    }
}
