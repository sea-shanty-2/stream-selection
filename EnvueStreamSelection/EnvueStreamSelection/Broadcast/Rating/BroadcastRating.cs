namespace EnvueStreamSelection.Broadcast.Rating
{
    public class BroadcastRating : IBroadcastRating
    {
        public int Weight { get; }
        public RatingPolarity Polarity { get; }

        public BroadcastRating(RatingPolarity polarity, int weight = 1)
        {
            Polarity = polarity;
            Weight = weight;
        }
    }
}