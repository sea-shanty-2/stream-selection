using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public interface IBroadcast
    {
        string GetIdentifier();
        IEnumerable<IRating> GetRatings();
    }
}