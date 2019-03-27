using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public interface IBroadcastSelector
    {
        IBroadcast SelectFrom(ICollection<IBroadcast> broadcasts);
    }
}