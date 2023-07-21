namespace Loging
{
    internal class AdditionalLogWriterToConsoleLogWriter : ConsoleLogWriter
    {
        private readonly ILogger _additionalLogWriter;

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