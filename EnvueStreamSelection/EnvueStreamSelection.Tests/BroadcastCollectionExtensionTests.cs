using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EnvueStreamSelection.Tests
{
    public class BroadcastCollectionExtensionTests
    {
        [Test]
        public void TestNormaliseEmpty()
        {
            var broadcasts = Enumerable.Empty<IBroadcast>().ToList();
            var normalised = broadcasts.GetNormalisedBitrates();
            
            Assert.AreEqual(0, normalised.Count);
        }

        [Test]
        public void TestNormaliseSingleInvalidBitrate()
        {
            var broadcast = new MockBroadcast {Bitrate = 0};
            var normalised = new List<IBroadcast> {broadcast}.GetNormalisedBitrates();

            Assert.AreEqual(normalised[broadcast], 0);
        }

        [Test]
        public void TestNormaliseSingleValidBitrate([Values(10, 100, 1000, 10000)] int bitrate)
        {
            var broadcast = new MockBroadcast {Bitrate = bitrate};
            var normalised = new List<IBroadcast> {broadcast}.GetNormalisedBitrates();

            Assert.AreEqual(normalised[broadcast], 1D);
        }

        [Test]
        public void TestNormaliseMultipleValidBitrates()
        {
            var lowBitrateBroadcast = new MockBroadcast { Bitrate = 500 * 1024 };
            var highBitrateBroadcast = new MockBroadcast { Bitrate = 2000 * 1024 };
            var normalised = new List<IBroadcast> { lowBitrateBroadcast, highBitrateBroadcast }.GetNormalisedBitrates();
            
            Assert.Less(normalised[lowBitrateBroadcast], normalised[highBitrateBroadcast]);
        }
    }
}