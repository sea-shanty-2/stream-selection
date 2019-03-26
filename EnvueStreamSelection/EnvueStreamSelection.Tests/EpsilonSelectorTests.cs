using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using EnvueStreamSelection;
using NUnit.Framework;

namespace Tests
{
    class MockBroadcast : IBroadcast
    {
        private readonly IEnumerable<IRating> _ratings;

        public MockBroadcast(int numberOfRatings)
        {
            _ratings = Enumerable.Range(0, numberOfRatings).Select(_ => new MockRating());
        }
        
        public string GetIdentifier()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IRating> GetRatings()
        {
            return _ratings;
        }
    }

    class MockRating : IRating
    {
        public double GetWeight()
        {
            return 0;
        }
    }
    
    public class EpsilonSelectorTests
    {
        private const double Delta = 0.01;
            
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNoImpressions()
        {
            var broadcasts = Enumerable.Empty<IBroadcast>();
            Assert.AreEqual(1D, new ExponentialEpsilonSelector().SelectFrom(broadcasts), Delta);
        }

        [Test]
        public void TestWithImpressions()
        {
            var selector = new ExponentialEpsilonSelector(0.05D, 0.1D);
            
            // Create a number of broadcasts with 50 impressions in total
            var broadcasts = Enumerable.Range(0, 5).Select(i => new MockBroadcast(10));
            
            Assert.AreEqual( 0.17D, selector.SelectFrom(broadcasts), Delta);
        }

        [Test]
        public void TestWithManyImpressions()
        {
            const double baseEpsilon = 0.1D;
            var selector = new ExponentialEpsilonSelector(0.05D, baseEpsilon);
            
            // Create a number of broadcasts with 5000 impressions in total
            var broadcasts = Enumerable.Range(0, 50).Select(i => new MockBroadcast(100));

            Assert.AreEqual(baseEpsilon, selector.SelectFrom(broadcasts), Delta);
        }
    }
}