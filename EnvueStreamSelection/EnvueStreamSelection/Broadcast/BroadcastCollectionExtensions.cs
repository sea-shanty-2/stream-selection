using System.Collections.Generic;
using System.Linq;

namespace EnvueStreamSelection.Broadcast
{
    public static class BroadcastCollectionExtensions
    {
        public static Dictionary<IBroadcast, double> GetNormalisedBitrates(this ICollection<IBroadcast> broadcasts)
        {
            if (broadcasts.Count == 0)
                return new Dictionary<IBroadcast, double>();
            
            var maxBitrate = broadcasts.Max(e => e.Bitrate);
            return broadcasts.ToDictionary(b => b, b => maxBitrate > 0 ? b.Bitrate / (double) maxBitrate : 0D);
        }
    }
}