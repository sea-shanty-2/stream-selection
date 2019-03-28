using System;
using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Selector.EpsilonGreedy
{
    /* Epsilon selector with exponential decay */
    public class ExponentialEpsilonComputer : IEpsilonComputer
    {
        private readonly double _baseEpsilon;
        private readonly double _decayFactor;

        public ExponentialEpsilonComputer(double decayFactor = 0.05D, double baseEpsilon = 0.1D)
        {
            _decayFactor = decayFactor;
            _baseEpsilon = baseEpsilon;
        }
        
        public float ComputeFrom(ICollection<IBroadcast> broadcasts)
        {
            var numberOfImpressions = broadcasts.Sum(b => b.Ratings.Count);

            return (float) Math.Min(1, Math.Pow(1 - _decayFactor, numberOfImpressions) + _baseEpsilon);
        }
    }
}