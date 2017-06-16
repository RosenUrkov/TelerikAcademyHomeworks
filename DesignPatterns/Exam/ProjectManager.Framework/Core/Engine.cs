using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using System;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private readonly IProcessor processor;
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(IProcessor processor, IWriter writer, IReader reader)
        {
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();
            Guard.WhenArgument(writer, "Engine Writer provider").IsNull().Throw();
            Guard.WhenArgument(reader, "Engine Reader provider").IsNull().Throw();
            
            this.processor = processor;
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            while (true)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                this.processor.ProcessCommand(commandLine);
            }
        }
    }
}
