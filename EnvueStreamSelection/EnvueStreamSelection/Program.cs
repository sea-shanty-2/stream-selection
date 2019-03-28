using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EnvueStreamSelection.Broadcast;
using EnvueStreamSelection.Broadcast.Rating;
using EnvueStreamSelection.Selector.Autonomous;
using EnvueStreamSelection.Selector.EpsilonGreedy;

namespace EnvueStreamSelection
{
    class Program
    {
        static void Main(string[] args)
        {
            var horrible = new Broadcast.Broadcast()
            {
                Stability = 0f,
                Bitrate = 256 * 1024,
                Identifier = "Horrible",
                Ratings = new List<IBroadcastRating> { new BroadcastRating(RatingPolarity.Positive), new BroadcastRating(RatingPolarity.Negative) }
            };
            
            var bad = new Broadcast.Broadcast()
            {
                Stability = 0.5f,
                Bitrate = 1024 * 1024,
                Identifier = "Bad",
                Ratings = new List<IBroadcastRating>()
            };

            var better = new Broadcast.Broadcast()
            {
                Stability = 0.7f,
                Bitrate = 2048 * 1024,
                Identifier = "Better",
                Ratings = new List<IBroadcastRating>()  { new BroadcastRating(RatingPolarity.Positive) }
            };

            var perfect = new Broadcast.Broadcast()
            {
                Stability = 1f,
                Bitrate = 4096 * 1024,
                Identifier = "Perfect",
                Ratings = new List<IBroadcastRating>(){ new BroadcastRating(RatingPolarity.Negative), new BroadcastRating(RatingPolarity.Negative) }
            };

            var epsilon = new EpsilonGreedySelector(new ExponentialEpsilonComputer(), new BestBroadcastSelector(),
                new AutonomousBroadcastSelector());
            var dict = new ConcurrentDictionary<IBroadcast, int>();
            for (var i = 0; i < 10000; i++)
            {
                var selection = epsilon.SelectFrom(new List<IBroadcast> {horrible, bad, better, perfect});
                dict.AddOrUpdate(selection, 1, (id, count) => count + 1);
            }

            WritePercentages(dict);
        }

        private static void WritePercentages(IDictionary<IBroadcast, int> frequencies)
        {
            var sumFrequencies = frequencies.Sum(f => f.Value);
            
            foreach (var (key, value) in frequencies)
            {
                Console.WriteLine($"{key.Identifier}: {value / (double) sumFrequencies * 100}%");
            }
        }
    }
}
