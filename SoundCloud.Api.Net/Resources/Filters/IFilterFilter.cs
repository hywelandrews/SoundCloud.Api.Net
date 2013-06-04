namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface IFilterFilter<out T>
    {
        T Filter(Resources.Filters.Filter type);
    }
}
