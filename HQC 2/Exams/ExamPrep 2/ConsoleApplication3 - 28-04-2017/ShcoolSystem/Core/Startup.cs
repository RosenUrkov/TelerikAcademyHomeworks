namespace SchoolSystem.Core
{
    using SchoolSystem.Models;
    using Utils;

    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var parser = new CommandParser();

            var engine = new Engine(reader, writer, parser);
            engine.Start();
        }
    }
}
