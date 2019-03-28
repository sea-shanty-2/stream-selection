using System.Collections.Generic;
using EnvueStreamSelection.Broadcast.Rating;

namespace EnvueStreamSelection.Broadcast
{
    public class Broadcast : IBroadcast
    {
        public string Identifier { get; set; }
        public int Bitrate { get; set; }
        public float Stability { get; set; }
        public ICollection<IBroadcastRating> Ratings { get; set; }
    }
}