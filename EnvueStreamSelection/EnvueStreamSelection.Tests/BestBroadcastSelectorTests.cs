using System.Linq;
using NUnit.Framework;

namespace EnvueStreamSelection.Tests
{
    public class BestBroadcastSelectorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNoBroadcasts()
        {
            var selector = new BestBroadcastSelector();
            Assert.Throws<NoBroadcastsException>(
                delegate { selector.SelectFrom(Enumerable.Empty<IBroadcast>().ToList<IBroadcast>()); });
        }
    }
}