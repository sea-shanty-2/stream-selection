using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public class EpsilonGreedy : IStreamSelector
    {
        private readonly IEpsilonSelector _epsilonSelector;

        public EpsilonGreedy(IEpsilonSelector epsilonSelector)
        {
            this._epsilonSelector = epsilonSelector;
        }
        
        public IBroadcast SelectFrom(IEnumerable<IBroadcast> broadcasts)
        {
            var epsilon = this._epsilonSelector.SelectFrom(broadcasts);
            
            throw new System.NotImplementedException();
        }
    }
}