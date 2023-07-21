namespace Loging
{
    internal class ConsoleLogWriter : ILogger
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }
}