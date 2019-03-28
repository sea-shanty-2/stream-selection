using System.Collections.Generic;
using System.Linq;

namespace EnvueStreamSelection
{
    public static class BroadcastCollectionExtensions
    {
        public static Dictionary<IBroadcast, int> GetNormalisedBitrates(this ICollection<IBroadcast> broadcasts)
        {
            if (broadcasts.Count == 0)
                return new Dictionary<IBroadcast, int>();
            
            var maxBitrate = broadcasts.Max(e => e.Bitrate);
            return broadcasts.ToDictionary(b => b, b => maxBitrate > 0 ? b.Bitrate / maxBitrate : 0);
        }
    }
}