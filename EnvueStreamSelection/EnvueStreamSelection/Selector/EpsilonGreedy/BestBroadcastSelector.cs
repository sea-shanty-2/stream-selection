using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;
using EnvueStreamSelection.Exception;

namespace EnvueStreamSelection.Selector.EpsilonGreedy
{
    public class BestBroadcastSelector : IBroadcastSelector
    {
        public IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts)
        {
            if (!broadcasts.Any())
                throw new NoBroadcastsException();

            // Sort broadcasts by score and select the best one
            return broadcasts.OrderByDescending(b => b.GetScore()).First();
        }
    }
}