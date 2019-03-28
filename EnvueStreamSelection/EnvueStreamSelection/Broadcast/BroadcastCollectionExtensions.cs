using System.Collections.Generic;
using System.Linq;

namespace EnvueStreamSelection
{
    public static class BroadcastCollectionExtensions
    {
        public static Dictionary<IBroadcast, int> GetNormalisedBitrates(ICollection<IBroadcast> broadcasts)
        {
            var maxBitrate = broadcasts.Max(e => e.Bitrate);
            return broadcasts.ToDictionary(b => b, b => b.Bitrate / maxBitrate);
        }
    }
}