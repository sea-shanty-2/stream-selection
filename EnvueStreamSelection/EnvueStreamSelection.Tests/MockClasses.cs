using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection;

namespace EnvueStreamSelection.Tests
{
    internal class MockBroadcast : IBroadcast
    {
        public string Identifier { get; set; }
        public int Bitrate { get; set; }
        public float Shakiness { get; set; }
        public ICollection<IBroadcastRating> Ratings { get; set; }

        public MockBroadcast(int numberOfRatings)
        {
            Ratings = Enumerable.Range(0, numberOfRatings).Select(_ => new MockRating()).ToList<IBroadcastRating>();
        }

        public MockBroadcast(params IBroadcastRating[] ratings)
        {
            Ratings = ratings;
        }
    }

    internal class MockRating : IBroadcastRating
    {
       
        public MockRating()
        {
            Polarity = RatingPolarity.Negative;
        }

        public MockRating(RatingPolarity polarity)
        {
            Polarity = polarity;
        }

        public MockRating(RatingPolarity polarity, int weight)
        {
            Polarity = polarity;
            Weight = weight;
        }

        public int Weight { get; }
        public RatingPolarity Polarity { get; }
    }
}