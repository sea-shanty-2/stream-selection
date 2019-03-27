namespace EnvueStreamSelection
{
    public interface IBroadcastRating
    {
        int GetWeight();
        RatingPolarity GetPolarity();
    }
}