namespace EnvueStreamSelection
{
    public interface IBroadcastRating
    {
        int Weight { get; }
        RatingPolarity Polarity { get; }
    }
}