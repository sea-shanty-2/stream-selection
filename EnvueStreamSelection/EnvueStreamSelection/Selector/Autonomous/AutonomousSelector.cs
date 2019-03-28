using System.Collections.Generic;
using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Selector.Autonomous
{
    /* Select a broadcast from a collection of broadcasts based on autonomous features. */
    public class AutonomousSelector : IBroadcastSelector
    {
        private double StabilityWeight { get; }
        private double BitrateWeight { get; }
        private double BaseWeight { get; }

        public AutonomousSelector(double stabilityWeight = 2D, double bitrateWeight = 1D, double baseWeight = 1D)
        {
            StabilityWeight = stabilityWeight;
            BitrateWeight = bitrateWeight;
            BaseWeight = baseWeight;
        }
        
        public IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts)
        {
            throw new System.NotImplementedException();
        }
    }
}