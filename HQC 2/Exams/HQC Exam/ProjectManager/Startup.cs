namespace ProjectManager
{
    using Core;
    using Core.Providers;
    using ProjectManager.Data;
    using ProjectManager.Models;

    public class Startup
    {
        public static void Main()
        {
            var fileLogger = new FileLogger();

            var datebase = new Database();
            var modelsFactory = new ModelsFactory();
            var cmdsFactory = new CommandsFactory(datebase, modelsFactory);

            var cmdProcessor = new CommandProcessor(cmdsFactory);

            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();

            var engine = new Engine(cmdProcessor, writer, reader, fileLogger);
            engine.Start();
        }
    }
}
