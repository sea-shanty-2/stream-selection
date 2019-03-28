using System.Collections.Generic;
using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Exception
{
    public class InvalidAutonomousSelectionException : System.Exception
    {
        private ICollection<IBroadcast> Broadcasts { get; }

        public InvalidAutonomousSelectionException(ICollection<IBroadcast> broadcasts)
        {
            Broadcasts = broadcasts;
        }
    }
}