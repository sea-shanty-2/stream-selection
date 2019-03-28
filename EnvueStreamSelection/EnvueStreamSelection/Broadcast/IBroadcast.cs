using System.Collections.Generic;
using System.ComponentModel;

namespace EnvueStreamSelection
{
    public interface IBroadcast
    {
        string Identifier { get; }
        int Bitrate { get; }
        float Shakiness { get; }
        ICollection<IBroadcastRating> Ratings { get;  }
    }
}