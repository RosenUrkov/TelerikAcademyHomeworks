using System;
using Ninject.Extensions.Interception;
using Academy.Core.Contracts;

namespace Academy.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly IWriter writer;

        public LoggingInterceptor(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            this.writer.Write($"{invocation.Request.Method.Name} method of the {invocation.Request.Target.GetType().Name} class was called..\n");
            invocation.Proceed();
            invocation.ReturnValue = "intercepted command";
        }
    }
}
