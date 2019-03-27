using System.Collections;
using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public interface IEpsilonComputer
    {
        float ComputeFrom(ICollection<IBroadcast> broadcasts);
    }
}