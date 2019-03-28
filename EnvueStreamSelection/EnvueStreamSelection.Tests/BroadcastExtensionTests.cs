using EnvueStreamSelection.Broadcast;
using NUnit.Framework;

namespace EnvueStreamSelection.Tests
{
    public class BroadcastExtensionTests
    {
        private const double Delta = 0.01D;

        [Test]
        public void TestGetWeightedPolaritiesNoRatings()
        {
            var broadcast = new MockBroadcast(0);
            var polarities = broadcast.GetWeightedPolarities();
            
            Assert.AreEqual(0, polarities.Keys.Count);
        }
        
        [Test]
        public void TestGetWeightedPolaritiesWithRatings([Values(0, 5, 10)] int positiveWeight, [Values(0, 5, 10)] int negativeWeight)
        {
            var positiveRating = new MockRating(RatingPolarity.Positive, positiveWeight);
            var negativeRating = new MockRating(RatingPolarity.Negative, negativeWeight);
            var broadcast = new MockBroadcast(positiveRating, negativeRating);
            var polarities = broadcast.GetWeightedPolarities();
            
            Assert.AreEqual(positiveWeight, polarities[RatingPolarity.Positive]);
            Assert.AreEqual(negativeWeight, polarities[RatingPolarity.Negative]);
        }
        
        [Test]
        public void TestGetScoreNoRatings()
        {
            var broadcast = new MockBroadcast(0);
            var score = broadcast.GetScore();
            
            Assert.AreEqual(0D, score, Delta);
        }
        
        [Test]
        public void TestGetScoreWithRatings([Values(0, 5, 10)] int positiveWeight, [Values(0, 5, 10)] int negativeWeight)
        {
            var positiveRating = new MockRating(RatingPolarity.Positive, positiveWeight);
            var negativeRating = new MockRating(RatingPolarity.Negative, negativeWeight);
            var broadcast = new MockBroadcast(positiveRating, negativeRating);
            var score = broadcast.GetScore();

            var weightSum = positiveWeight + negativeWeight;
            var expected =  weightSum > 0 ? (double) positiveWeight / weightSum : 0D;
            
            Assert.AreEqual(expected, score, Delta);
        }
    }
}