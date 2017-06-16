using System;
using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class CommandExceptionHandlerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                throw new UserValidationException("No such command!");
            }
        }
    }
}
