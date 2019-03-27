using System;
using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public class EpsilonGreedy : IStreamSelector
    {
        private readonly IEpsilonSelector _epsilonSelector;

        public EpsilonGreedy(IEpsilonSelector epsilonSelector)
        {
            _epsilonSelector = epsilonSelector;
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
            
            return null;
        }

        private IBroadcast Exploit(ICollection<IBroadcast> broadcasts)
        {
            Console.WriteLine("exploit");
            
            return null;
        }
    }
}