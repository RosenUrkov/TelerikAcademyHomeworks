using System;
using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using Bytes2you.Validation;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class LogErrorInterceptor : IInterceptor
    {
        private const string UnexepectedMessage = "Opps, something happened. Check the log file :(";

        private readonly ILogger logger;
        private readonly IWriter writer;

        public LogErrorInterceptor(ILogger logger, IWriter writer)
        {
            Guard.WhenArgument(logger, "logger").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            
            this.logger = logger;
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (UserValidationException ex)
            {
                this.logger.Error(ex.Message);
                this.writer.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(UnexepectedMessage);
                this.logger.Error(ex.Message);
            }
        }
    }
}
