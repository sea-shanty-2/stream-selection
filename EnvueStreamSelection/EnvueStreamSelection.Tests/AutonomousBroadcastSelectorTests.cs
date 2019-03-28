using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;
using EnvueStreamSelection.Exception;
using EnvueStreamSelection.Selector.Autonomous;
using NUnit.Framework;

namespace EnvueStreamSelection.Tests
{
    [TestFixture]
    public class AutonomousBroadcastSelectorTests
    {
        [Test]
        public void TestSingleBroadcastSelected()
        {
            var broadcast = new MockBroadcast { Bitrate = 0, Stability = 0};
            var selection = new AutonomousBroadcastSelector().SelectFrom(new List<IBroadcast> {broadcast});

            Assert.IsNotNull(selection);
        }
        
        [Test]
        public void TestNoBroadcasts()
        {
            var selector = new AutonomousBroadcastSelector();
            Assert.Throws<NoBroadcastsException>(
                delegate { selector.SelectFrom(Enumerable.Empty<IBroadcast>().ToList()); });
        }
    }
}