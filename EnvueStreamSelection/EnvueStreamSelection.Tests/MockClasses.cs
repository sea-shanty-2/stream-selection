using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection;

namespace EnvueStreamSelection.Tests
{
    internal class MockBroadcast : IBroadcast
    {
        private readonly ICollection<IBroadcastRating> _ratings;

        public MockBroadcast(int numberOfRatings)
        {
            _ratings = Enumerable.Range(0, numberOfRatings).Select(_ => new MockRating()).ToList<IBroadcastRating>();
        }

        public MockBroadcast(params IBroadcastRating[] ratings)
        {
            _ratings = ratings;
        }
        
        public string GetIdentifier() => throw new System.NotImplementedException();

        public ICollection<IBroadcastRating> GetRatings() => _ratings;
    }

    internal class MockRating : IBroadcastRating
    {
        private readonly RatingPolarity _polarity;
        private readonly int _weight;
        
        public MockRating()
        {
            _polarity = RatingPolarity.Negative;
        }

        public MockRating(RatingPolarity polarity)
        {
            _polarity = polarity;
        }

        public MockRating(RatingPolarity polarity, int weight)
        {
            _polarity = polarity;
            _weight = weight;
        }

        public int GetWeight() => _weight;

        public RatingPolarity GetPolarity() => _polarity;
    }
}