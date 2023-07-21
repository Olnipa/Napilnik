namespace Loging
{

    internal class SecureLogWriter : ILogger
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
}