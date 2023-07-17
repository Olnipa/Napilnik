using Loging;

namespace Napilnik
{
    internal class Program
    {
        private const string FileLog1 = "LogMessage1";
        private const string FileLog2 = "LogMessage2";
        private const string FileLog3 = "LogMessage3";
        private const string FileLog4 = "LogMessage4";
        private const string FileLog5 = "LogMessage5";

        static void Main(string[] args)
        {
            Pathfinder pathfinder1 = new Pathfinder(new FileLogWriter());
            Pathfinder pathfinder2 = new Pathfinder(new ConsoleLogWriter());
            Pathfinder pathfinder3 = new Pathfinder(new SecureLogWriter(new FileLogWriter()));
            Pathfinder pathfinder4 = new Pathfinder(new SecureLogWriter(new ConsoleLogWriter()));
            Pathfinder pathfinder5 = new Pathfinder(new AdditionalLogWriterToConsoleLogWriter(new SecureLogWriter(new FileLogWriter())));

            pathfinder1.Find(FileLog1);
            pathfinder2.Find(FileLog2);
            pathfinder3.Find(FileLog3);
            pathfinder4.Find(FileLog4);
            pathfinder5.Find(FileLog5);
        }
    }

    class Pathfinder
    {
        private ILogger Logger;

        public Pathfinder(ILogger logger)
        {
            Logger = logger;
        }

        public void Find(string message)
        {
            Logger.WriteError(message);
        }
    }
}