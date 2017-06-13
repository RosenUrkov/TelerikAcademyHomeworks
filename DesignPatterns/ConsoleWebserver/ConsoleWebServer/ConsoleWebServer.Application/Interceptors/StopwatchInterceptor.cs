using System;
using Ninject.Extensions.Interception;
using System.Diagnostics;

namespace ConsoleWebServer.Application.Interceptors
{
    public class StopwatchInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();

            Console.WriteLine($"{invocation.Request.Target.GetType().Name} was invoked with {invocation.Request.Method.Name} method and proceeded for {stopwatch.ElapsedTicks} ticks");
        }
    }
}
