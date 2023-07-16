namespace Loging
{
    interface ILogger
    {
        void WriteError(string message);
    }

    class BaseLogWriter : ILogger
    {
        public virtual void WriteError(string message) { }
    } 

    class ConsoleLogWriter : ILogger
    {
        private ILogger _logger;

        public ConsoleLogWriter(ILogger logger)
        {
            _logger = logger;
        }

        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
            _logger.WriteError(message);
        }
    }

    class FileLogWriter : ILogger
    {
        private ILogger _logger;

        public FileLogWriter(ILogger logger)
        {
            _logger = logger;
        }

        public void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
            _logger.WriteError(message);
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
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                _logger.WriteError(message);
            }
        }
    }
}