using Ninject;

namespace MutithreadingAndAsyncProgramming
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var cycles = new StandardKernel(new Module()).Get<ICycles>();

            var number = 100_000_000;
            cycles.StartCycling(number);           
        }        
    }
}
