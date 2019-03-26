using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public interface IStreamSelector
    {
        IBroadcast SelectFrom(IEnumerable<IBroadcast> broadcasts);
    }
}