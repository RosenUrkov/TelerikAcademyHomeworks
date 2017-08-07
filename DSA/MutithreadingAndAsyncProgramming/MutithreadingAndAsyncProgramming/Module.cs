using System;
using Ninject.Modules;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace MutithreadingAndAsyncProgramming
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICycles>()
                .To<Cycles>()
                .InSingletonScope()
                .Intercept()
                .With(
                new ActionInterceptor((invocation) =>
                {
                    Console.WriteLine(invocation.Request.Method.Name + " started!");
                    invocation.Proceed();
                }));
        }
    }
}
