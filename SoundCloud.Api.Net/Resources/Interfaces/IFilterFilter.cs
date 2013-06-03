namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IFilterFilter<out T>
    {
        T Filter(Filters type);
    }
}
