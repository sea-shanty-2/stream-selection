using System;
using System.Collections.Generic;
using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Selector.EpsilonGreedy
{
    public class EpsilonGreedySelector : IBroadcastSelector
    {
        private readonly IEpsilonComputer _epsilonComputer;
        private readonly IBroadcastSelector _explorationSelector;
        private readonly IBroadcastSelector _exploitationSelector;

        public EpsilonGreedySelector(IEpsilonComputer epsilonComputer, IBroadcastSelector explorationSelector, IBroadcastSelector exploitationSelector)
        {
            _epsilonComputer = epsilonComputer;
            _explorationSelector = explorationSelector;
            _exploitationSelector = exploitationSelector;
        }
        
        public IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts)
        {
            var epsilon = _epsilonComputer.ComputeFrom(broadcasts);
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
            
            return _exploitationSelector.SelectFrom(broadcasts);
        }
    }
}