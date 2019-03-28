using System;
using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;
using EnvueStreamSelection.Exception;

namespace EnvueStreamSelection.Selector.Autonomous
{
    /* Select a broadcast from a collection of broadcasts based on autonomous features. */
    public class AutonomousSelector : IBroadcastSelector
    {
        private double StabilityWeight { get; }
        private double BitrateWeight { get; }

        public AutonomousSelector(double stabilityWeight = 2D, double bitrateWeight = 1D)
        {
            StabilityWeight = stabilityWeight;
            BitrateWeight = bitrateWeight;
        }
        
        public IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts)
        {
            if (!broadcasts.Any())
                throw new NoBroadcastsException();

            var weightedBroadcasts = GetWeightedBroadcasts(broadcasts);
            var weightSum = weightedBroadcasts.Sum(w => w.Weight);
            var random = new Random().Next(weightSum);

            foreach (var weightedBroadcast in weightedBroadcasts)
            {
                if (random < weightedBroadcast.Weight)
                    return weightedBroadcast.Broadcast;
            }

            // If this point is reached, no broadcast was selected
            throw new InvalidAutonomousSelectionException(broadcasts);
        }

        private List<WeightedBroadcast> GetWeightedBroadcasts(ICollection<IBroadcast> broadcasts)
        {
            var sum = 0;

            // Every element is incremented with 1 to ensure that something is selected
            return broadcasts.Select(b => new WeightedBroadcast
            {
                Broadcast = b,
                Weight = sum +=
                    (int) Math.Ceiling(b.Bitrate * BitrateWeight + b.Stability * StabilityWeight) + 1
            }).OrderBy(w => w.Weight).ToList();
        }
    }
}