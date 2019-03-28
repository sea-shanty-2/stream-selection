using System;
using System.Collections.Generic;
using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Selector.EpsilonGreedy
{
    public class EpsilonGreedySelector : IBroadcastSelector
    {
        private IEpsilonComputer EpsilonComputer { get; }
        private IBroadcastSelector ExplorationSelector { get; }
        private IBroadcastSelector ExploitationSelector { get; }
        private Random Random { get; }

        public EpsilonGreedySelector(IEpsilonComputer epsilonComputer, IBroadcastSelector exploitationSelector, IBroadcastSelector explorationSelector)
        {
            EpsilonComputer = epsilonComputer;
            ExplorationSelector = explorationSelector;
            ExploitationSelector = exploitationSelector;
            Random = new Random();
        }
        
        public IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts)
        {
            var epsilon = EpsilonComputer.ComputeFrom(broadcasts);
            var randomDouble = Random.NextDouble();

            return randomDouble < epsilon ? Explore(broadcasts) : Exploit(broadcasts);
        }

        private IBroadcast Explore(ICollection<IBroadcast> broadcasts) => ExplorationSelector.SelectFrom(broadcasts);

        private IBroadcast Exploit(ICollection<IBroadcast> broadcasts) => ExploitationSelector.SelectFrom(broadcasts);
    }
}