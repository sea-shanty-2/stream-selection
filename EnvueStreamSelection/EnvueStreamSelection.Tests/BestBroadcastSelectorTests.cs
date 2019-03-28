using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;
using EnvueStreamSelection.Exception;
using EnvueStreamSelection.Selector.EpsilonGreedy;
using NUnit.Framework;

namespace EnvueStreamSelection.Tests
{
    public class BestBroadcastSelectorTests
    {
        [Test]
        public void TestNoBroadcasts()
        {
            var selector = new BestBroadcastSelector();
            Assert.Throws<NoBroadcastsException>(
                delegate { selector.SelectFrom(Enumerable.Empty<IBroadcast>().ToList<IBroadcast>()); });
        }

        [Test]
        public void TestWithBroadcasts()
        {
            var lowRatedBroadcast = new MockBroadcast(new MockRating(RatingPolarity.Negative, 2), new MockRating(RatingPolarity.Positive, 1));
            var highRatedBroadcast = new MockBroadcast(new MockRating(RatingPolarity.Negative, 1), new MockRating(RatingPolarity.Positive, 2));
            
            Assert.AreEqual(highRatedBroadcast, new BestBroadcastSelector().SelectFrom(new List<IBroadcast> {lowRatedBroadcast, highRatedBroadcast}));
        }
    }
}