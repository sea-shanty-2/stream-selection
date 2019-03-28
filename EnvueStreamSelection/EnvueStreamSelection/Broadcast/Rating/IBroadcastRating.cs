namespace EnvueStreamSelection.Broadcast.Rating
{
    public interface IBroadcastRating
    {
        int Weight { get; }
        RatingPolarity Polarity { get; }
    }
}