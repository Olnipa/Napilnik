using Loging;

namespace Napilnik
{

    internal class Pathfinder
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