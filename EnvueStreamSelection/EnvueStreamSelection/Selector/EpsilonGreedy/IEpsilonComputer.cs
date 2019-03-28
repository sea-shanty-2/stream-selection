using System.Collections;
using System.Collections.Generic;
using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Selector.EpsilonGreedy
{
    public interface IEpsilonComputer
    {
        float ComputeFrom(ICollection<IBroadcast> broadcasts);
    }
}