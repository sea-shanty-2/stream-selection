namespace EnvueStreamSelection.Broadcast.Rating
{
    public class BroadcastRating : IBroadcastRating
    {
        public int Weight { get; set; }
        public RatingPolarity Polarity { get; set; }

        public BroadcastRating(RatingPolarity polarity, int weight = 1)
        {
            Polarity = polarity;
            Weight = weight;
        }
    }
}