using System.Collections.Generic;
using System.Linq;

namespace EnvueStreamSelection
{
    public static class BroadcastExtensions
    {
        public static IDictionary<RatingPolarity, int> GetWeightedPolarities(this IBroadcast broadcasts) => broadcasts
            .GetRatings().GroupBy(r => r.GetPolarity()).ToDictionary(g => g.Key, g => g.Sum(r => r.GetWeight()));
        
        public static double GetScore(this IBroadcast broadcast)
        {
            var weightedPolarities = GetWeightedPolarities(broadcast);
            var weightSum = weightedPolarities.Sum(w => w.Value);

            if (weightSum == 0 || !weightedPolarities.TryGetValue(RatingPolarity.Positive, out var positiveWeight) || positiveWeight == 0)
                return 0;

            return (double) weightSum / positiveWeight;
        }
    }
}