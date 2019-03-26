using System.Collections;
using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public interface IEpsilonSelector
    {
        float SelectFrom(IEnumerable<IBroadcast> broadcasts);
    }
}