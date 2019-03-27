using System.Collections.Generic;

namespace EnvueStreamSelection
{
    public interface IBroadcast
    {
        string GetIdentifier();
        ICollection<IBroadcastRating> GetRatings();
    }
}