using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection;

namespace Tests
{
    internal class MockBroadcast : IBroadcast
    {
        private readonly ICollection<IRating> _ratings;

        public MockBroadcast(int numberOfRatings)
        {
            _ratings = Enumerable.Range(0, numberOfRatings).Select(_ => new MockRating()).ToList<IRating>();
        }
        
        public string GetIdentifier()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<IRating> GetRatings() => _ratings;
    }

    internal class MockRating : IRating
    {
        public double GetWeight() => 0;
    }
}