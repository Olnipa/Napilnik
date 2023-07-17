namespace Loging
{
    interface ILogger
    {
        void WriteError(string message);
    }

    class ConsoleLogWriter : ILogger
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogWriter : ILogger
    {
        public void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class SecureLogWriter : ILogger
    {
        private ILogger _logger;

        public SecureLogWriter(ILogger logger)
        {
            _logger = logger;
        }

        public void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _logger.WriteError(message);
            }
        }
    }

    class AdditionalLogWriterToConsoleLogWriter : ConsoleLogWriter
    {
        private ILogger _additionalLogWriter;

        public AdditionalLogWriterToConsoleLogWriter(ILogger additionalLogWriterToConsoleLogWriter)
        {
            _additionalLogWriter = additionalLogWriterToConsoleLogWriter;
        }

        public override void WriteError(string message)
        {
            _additionalLogWriter.WriteError(message);
            base.WriteError(message);
        }
    }
}