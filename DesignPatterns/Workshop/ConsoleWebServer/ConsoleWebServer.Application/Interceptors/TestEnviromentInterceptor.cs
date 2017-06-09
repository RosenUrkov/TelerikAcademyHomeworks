using System;
using Ninject.Extensions.Interception;
using System.Configuration;

namespace ConsoleWebServer.Application.Interceptors
{
    public class TestEnviromentInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var isTestEnvironment = bool.Parse(ConfigurationManager.AppSettings.Get("isTestEnvironment"));

            if (isTestEnvironment)
            {
                invocation.Proceed();
            }
        }
    }
}
