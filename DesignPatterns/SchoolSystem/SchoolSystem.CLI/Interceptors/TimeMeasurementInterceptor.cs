using System;
using Ninject.Extensions.Interception;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Cli.Interceptors
{
    public class TimeMeasurementInterceptor : IInterceptor
    {
        private readonly ITimeMeasurementProvider measurementProvider;
        private readonly IWriter writer;
        
        public TimeMeasurementInterceptor(ITimeMeasurementProvider measurementProvider, IWriter writer)
        {
            this.measurementProvider = measurementProvider;
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Request.Method.Name;
            var typeName = invocation.Request.Target.GetType().Name.Replace("Proxy", string.Empty);

            this.writer.WriteLine($"Calling method {methodName} of type {typeName}...");

            this.measurementProvider.Start();
            invocation.Proceed();
            this.measurementProvider.Stop();

            var timeElapsed = this.measurementProvider.GetMeasuredTime().ToString();
            this.writer.WriteLine($"Total execution time for method {methodName} of type {typeName} is {timeElapsed} milliseconds.");
        }
    }
}
