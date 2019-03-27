using System;
using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public class EpsilonGreedySelector : IBroadcastSelector
    {
        private readonly IEpsilonSelector _epsilonSelector;
        private readonly IBroadcastSelector _explorationSelector;
        
        public EpsilonGreedySelector(IEpsilonSelector epsilonSelector, IBroadcastSelector explorationSelector)
        {
            _epsilonSelector = epsilonSelector;
            _explorationSelector = explorationSelector;
        }
        
        public IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts)
        {
            var epsilon = _epsilonSelector.SelectFrom(broadcasts);
            var rand = new Random().NextDouble();

            return rand < epsilon ? Explore(broadcasts) : Exploit(broadcasts);
        }

        private IBroadcast Explore(ICollection<IBroadcast> broadcasts)
        {
            Console.WriteLine("explore");

            return _explorationSelector.SelectFrom(broadcasts);
        }

        private IBroadcast Exploit(ICollection<IBroadcast> broadcasts)
        {
            Console.WriteLine("exploit");
            
            return null;
        }
    }
}