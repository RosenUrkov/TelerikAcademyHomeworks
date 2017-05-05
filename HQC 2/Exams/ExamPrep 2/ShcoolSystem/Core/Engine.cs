namespace SchoolSystem.Core
{
    using Models;
    using SchoolSystem.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Utils;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser parser;

        public Engine(IReader reader, IWriter writer, ICommandParser parser, IValidator validator = null)
        {
            if (validator == null)
            {
                this.Validator = new Validator();
            }
            else
            {
                this.Validator = validator;
            }

            this.Reader = reader;
            this.Writer = writer;
            this.Parser = parser;
        }

        public static Dictionary<int, ITeacher> Teachers { get; private set; } = new Dictionary<int, ITeacher>();

        public static Dictionary<int, IStudent> Students { get; private set; } = new Dictionary<int, IStudent>();

        protected IValidator Validator { get; private set; }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }

            private set
            {
                this.Validator.ValidateNullObject(value, "Writer must not be null");
                this.writer = value;
            }
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }

            private set
            {
                this.Validator.ValidateNullObject(value, "Reader must not be null");
                this.reader = value;
            }
        }

        public ICommandParser Parser
        {
            get
            {
                return this.parser;
            }

            private set
            {
                this.Validator.ValidateNullObject(value, "Parser must not be null");
                this.parser = value;
            }
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var command = this.reader.ReadLine();
                    if (command == "End")
                    {
                        break;
                    }

                    var parameters = command.Split(' ').ToList();
                    parameters.RemoveAt(0);

                    var parsedCommand = this.Parser.ParseCommand(command);
                    this.writer.WriteLine(parsedCommand.Execute(parameters));
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
