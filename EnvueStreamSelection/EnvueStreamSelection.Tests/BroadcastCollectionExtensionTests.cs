using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;
using NUnit.Framework;

namespace EnvueStreamSelection.Tests
{
    [TestFixture]
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

            Assert.AreEqual(0D, normalised[broadcast]);
        }

        [Test]
        public void TestNormaliseSingleValidBitrate([Values(512, 1024, 2048, 4096)] int bitrate)
        {
            var broadcast = new MockBroadcast {Bitrate = bitrate};
            var normalised = new List<IBroadcast> {broadcast}.GetNormalisedBitrates();

            Assert.AreEqual(1D, normalised[broadcast]);
        }

        [Test]
        public void TestNormaliseMultipleValidBitrates()
        {
            var lowBitrateBroadcast = new MockBroadcast { Bitrate = 512 * 1000 };
            var mediumBitrateBroadcast = new MockBroadcast { Bitrate = 2048 * 1000 };
            var highBitrateBroadcast = new MockBroadcast { Bitrate = 4096 * 1000 };
            var normalised = new List<IBroadcast> { lowBitrateBroadcast, mediumBitrateBroadcast, highBitrateBroadcast }.GetNormalisedBitrates();
            
            Assert.Less(normalised[lowBitrateBroadcast], normalised[mediumBitrateBroadcast]);
            Assert.Less(normalised[mediumBitrateBroadcast], normalised[highBitrateBroadcast]);
        }

        [Test]
        public void TestNormaliseMultipleInvalidBitrateMixin()
        {
            var invalidBitrateBroadcast = new MockBroadcast {Bitrate = 0};
            var validBitrateBroadcast = new MockBroadcast { Bitrate = 2048 * 1000 };
            var normalised = new List<IBroadcast> { invalidBitrateBroadcast, validBitrateBroadcast }.GetNormalisedBitrates();

            Assert.AreEqual(0D, normalised[invalidBitrateBroadcast]);
            Assert.AreEqual(1D, normalised[validBitrateBroadcast]);
        }
    }
}