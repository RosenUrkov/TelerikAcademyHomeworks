namespace ProjectManager.Core
{
    using Bytes2you.Validation;
    using Contracts;
    using ProjectManager.Common.CustomExceptions;
    using System;

    public class Engine : IEngine
    {
        private const string EndCommand = "exit";
        private const string EndCommandMessage = "Program terminated.";
        private const string GenericExceptionMessage = "Opps, something happened. :(";

        private IFileLogger logger;
        private ICommandProcessor processor;
        private IWriter writer;
        private IReader reader;

        public Engine(ICommandProcessor processor, IWriter writer, IReader reader, IFileLogger logger)
        {
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();
            Guard.WhenArgument(writer, "Engine Writer provider").IsNull().Throw();
            Guard.WhenArgument(reader, "Engine Reader provider").IsNull().Throw();

            this.logger = logger;
            this.processor = processor;
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            while (true)
            {
                var command = this.reader.ReadLine();

                if (command.ToLower() == EndCommand)
                {
                    this.writer.WriteLine(EndCommandMessage);
                    break;
                }

                try
                {
                    var executionResult = this.processor.Process(command);
                    this.writer.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(GenericExceptionMessage);
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
