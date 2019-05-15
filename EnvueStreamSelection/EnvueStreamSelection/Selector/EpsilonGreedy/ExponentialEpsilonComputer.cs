using System;
using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Selector.EpsilonGreedy
{
    /* Epsilon selector with exponential decay */
    public class ExponentialEpsilonComputer : IEpsilonComputer
    {
        private double BaseEpsilon { get; }
        private double DecayFactor { get; }

        public ExponentialEpsilonComputer(double decayFactor = 0.05D, double baseEpsilon = 0.1D)
        {
            DecayFactor = decayFactor;
            BaseEpsilon = baseEpsilon;
        }
        
        public float ComputeFrom(ICollection<IBroadcast> broadcasts)
        {
            var numberOfImpressions = broadcasts.Sum(b => b.Ratings.Sum(r => r.Weight));

            return (float) Math.Min(1, Math.Pow(1 - DecayFactor, numberOfImpressions) + BaseEpsilon);
        }
    }
}