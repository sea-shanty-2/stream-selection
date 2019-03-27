using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EnvueStreamSelection.Tests
{
    public class EpsilonComputerTests
    {
        private const double Delta = 0.01;
            
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNoImpressions()
        {
            var broadcasts = new List<IBroadcast>();
            Assert.AreEqual(1D, new ExponentialEpsilonComputer().ComputeFrom(broadcasts), Delta);
        }

        [Test]
        public void TestWithImpressions()
        {
            var selector = new ExponentialEpsilonComputer(0.05D, 0.1D);
            
            // Create a number of broadcasts with 50 impressions in total
            var broadcasts = Enumerable.Range(0, 5).Select(i => new MockBroadcast(10)).ToList<IBroadcast>();
            
            Assert.AreEqual( 0.17D, selector.ComputeFrom(broadcasts), Delta);
        }

        [Test]
        public void TestWithManyImpressions()
        {
            const double baseEpsilon = 0.1D;
            var selector = new ExponentialEpsilonComputer(0.05D, baseEpsilon);
            
            // Create a number of broadcasts with 5000 impressions in total
            var broadcasts = Enumerable.Range(0, 50).Select(i => new MockBroadcast(100)).ToList<IBroadcast>();

            Assert.AreEqual(baseEpsilon, selector.ComputeFrom(broadcasts), Delta);
        }
    }
}