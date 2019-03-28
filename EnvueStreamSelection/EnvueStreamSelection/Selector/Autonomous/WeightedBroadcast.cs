using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Selector.Autonomous
{
    public class WeightedBroadcast
    {
        public IBroadcast Broadcast { get; set; }
        public int Weight { get; set; }
    }
}