namespace AcademyEcosystemCLI.Core
{
    using Utils;

    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var validator = new Validator();

            var engine = new Engine(reader, writer, validator);
            engine.Start();
        }
    }
}
