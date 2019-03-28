using System.Collections.Generic;
using EnvueStreamSelection.Broadcast;

namespace EnvueStreamSelection.Selector
{
    public interface IBroadcastSelector
    {
        IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts);
    }
}