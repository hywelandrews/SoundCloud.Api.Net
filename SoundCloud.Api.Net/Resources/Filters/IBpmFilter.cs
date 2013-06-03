namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface IBpmFilter<out T>
    {
        T BpmFrom(double value);
        T BpmTo(double value);
    }
}
