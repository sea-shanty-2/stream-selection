using System;
using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;
using EnvueStreamSelection.Exception;

namespace EnvueStreamSelection.Selector.Autonomous
{
    /* Select a broadcast from a collection of broadcasts based on autonomous features. */
    public class AutonomousBroadcastSelector : IBroadcastSelector
    {
        private double StabilityWeight { get; }
        private double BitrateWeight { get; }
        private Random Random { get; }
        
        public AutonomousBroadcastSelector(double stabilityWeight = 1D, double bitrateWeight = 3D)
        {
            StabilityWeight = stabilityWeight;
            BitrateWeight = bitrateWeight;
            Random = new Random();
        }
        
        public IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts)
        {
            if (!broadcasts.Any())
                throw new NoBroadcastsException();

            var weightedBroadcasts = GetWeightedBroadcasts(broadcasts);
            var randomWeight = Random.Next(weightedBroadcasts.Last().Weight);
            var selection = weightedBroadcasts.FirstOrDefault(w => randomWeight < w.Weight);
            
            return selection?.Broadcast ?? throw new InvalidAutonomousSelectionException(broadcasts);
        }

        private List<WeightedBroadcast> GetWeightedBroadcasts(ICollection<IBroadcast> broadcasts)
        {
            // Normalize bitrates
            var normalisedBitrates = broadcasts.GetNormalisedBitrates();

            // Every element is incremented with 1 to ensure that something is selected
            var sum = 0;
            return broadcasts.Select(b => new WeightedBroadcast
            {
                Broadcast = b,
                Weight = sum +=
                    (int) Math.Ceiling(normalisedBitrates[b] * BitrateWeight + b.Stability * StabilityWeight) + 1
            }).OrderBy(w => w.Weight).ToList();
        }
    }
}