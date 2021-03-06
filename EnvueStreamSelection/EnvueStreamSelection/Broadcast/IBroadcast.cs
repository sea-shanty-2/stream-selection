using System.Collections.Generic;
using EnvueStreamSelection.Broadcast.Rating;

namespace EnvueStreamSelection.Broadcast
{
    public interface IBroadcast
    {
        string Identifier { get; }
        int Bitrate { get; }
        float Stability { get; }
        ICollection<IBroadcastRating> Ratings { get;  }
    }
}