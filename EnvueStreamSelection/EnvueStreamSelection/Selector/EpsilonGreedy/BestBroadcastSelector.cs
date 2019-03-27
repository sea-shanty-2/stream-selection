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
            
            throw new System.NotImplementedException();
        }
    }
}