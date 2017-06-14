using Academy.Container;
using Academy.Core;
using Academy.Core.Contracts;
using Ninject;

namespace Academy
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel(new AcademyModule());
            var engine = kernel.Get<IEngine>(AcademyModule.EngineName);

            engine.Start();
        }
    }
}
