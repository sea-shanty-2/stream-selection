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

        public EpsilonGreedySelector(IEpsilonComputer epsilonComputer, IBroadcastSelector explorationSelector, IBroadcastSelector exploitationSelector)
        {
            EpsilonComputer = epsilonComputer;
            ExplorationSelector = explorationSelector;
            ExploitationSelector = exploitationSelector;
        }
        
        public IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts)
        {
            var epsilon = EpsilonComputer.ComputeFrom(broadcasts);
            var rand = new Random().NextDouble();

            return rand < epsilon ? Explore(broadcasts) : Exploit(broadcasts);
        }

        private IBroadcast Explore(ICollection<IBroadcast> broadcasts)
        {
            Console.WriteLine("explore");

            return ExplorationSelector.SelectFrom(broadcasts);
        }

        private IBroadcast Exploit(ICollection<IBroadcast> broadcasts)
        {
            Console.WriteLine("exploit");
            
            return ExploitationSelector.SelectFrom(broadcasts);
        }
    }
}