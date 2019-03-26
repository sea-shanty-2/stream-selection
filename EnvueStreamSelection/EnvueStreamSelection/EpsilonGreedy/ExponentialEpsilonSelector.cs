using System;
using System.Collections.Generic;
using System.Linq;

namespace EnvueStreamSelection
{
    /* Epsilon selector with exponential decay */
    public class ExponentialEpsilonSelector : IEpsilonSelector
    {
        private readonly double _baseEpsilon;
        private readonly double _decayFactor;

        public ExponentialEpsilonSelector(double decayFactor = 0.05D, double baseEpsilon = 0.1D)
        {
            _decayFactor = decayFactor;
            _baseEpsilon = baseEpsilon;
        }
        
        public float SelectFrom(IEnumerable<IBroadcast> broadcasts)
        {
            var numberOfImpressions = broadcasts.Sum(b => b.GetRatings().Count());

            return (float) Math.Min(1, Math.Pow(1 - _decayFactor, numberOfImpressions) + _baseEpsilon);
        }
    }
}