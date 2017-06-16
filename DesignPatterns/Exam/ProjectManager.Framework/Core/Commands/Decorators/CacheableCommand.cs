using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        //private const string 
        private const string CommandName = "Execute";

        private readonly ICommand command;
        private readonly ICachingService cachingService;

        public CacheableCommand(ICommand command, ICachingService cachingService)
        {
            Guard.WhenArgument(command, "command").IsNull().Throw();
            Guard.WhenArgument(cachingService, "cachingService").IsNull().Throw();

            this.command = command;
            this.cachingService = cachingService;
        }

        public int ParameterCount
        {
            get
            {
                return this.command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            if (this.cachingService.IsExpired)
            {
                var commandExecution = this.command.Execute(parameters);

                this.cachingService.ResetCache();
                this.cachingService.AddCacheValue(this.command.GetType().Name, CommandName, commandExecution);
            }

            return (string)this.cachingService.GetCacheValue(this.command.GetType().Name, CommandName);
        }
    }
}
