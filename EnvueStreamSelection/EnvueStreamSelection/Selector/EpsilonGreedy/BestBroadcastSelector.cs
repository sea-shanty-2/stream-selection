using System.Collections.Generic;
using System.Linq;

namespace EnvueStreamSelection
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