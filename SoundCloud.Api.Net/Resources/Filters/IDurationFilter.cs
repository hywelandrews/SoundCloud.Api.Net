namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface IDurationFilter<out T>
    {
        T DurationFrom(int milliseconds);
        T DurationTo(int milliseconds);
    }
}
