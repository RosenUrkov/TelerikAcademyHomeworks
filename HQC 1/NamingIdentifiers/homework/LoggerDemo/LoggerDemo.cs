namespace WellNamedRefactoring
{
    public class LoggerDemo
    {
        private const int MAX_COUNT = 6;

        public static void Main()
        {
            var logger = new ConsoleLogger();
            logger.ConsoleLogBoolVariable(true);
        }
    }
}
