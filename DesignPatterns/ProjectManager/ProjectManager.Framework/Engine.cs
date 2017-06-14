using Bytes2you.Validation;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using System;
using System.Text;

namespace ProjectManager
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ILogger logger;
        private readonly IProcessor processor;

        public Engine(IReader reader, IWriter writer, ILogger logger, IProcessor processor)
        {
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(writer, "Engine Writer provider").IsNull().Throw();
            Guard.WhenArgument(reader, "Engine Reader provider").IsNull().Throw();

            this.processor = processor;
            this.writer = writer;
            this.reader = reader;
            this.logger = logger;
        }

        public void Start()
        {
            var builder = new StringBuilder();

            while(true)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    this.writer.Write(builder.ToString());
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.ProcessCommand(commandLine);
                    builder.AppendLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    builder.AppendLine(ex.Message);
                }
                catch (Exception ex)
                {
                    builder.AppendLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
