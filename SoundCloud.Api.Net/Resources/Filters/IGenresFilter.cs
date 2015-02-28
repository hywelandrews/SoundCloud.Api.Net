namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface IGenresFilter<out T>
    {
        T Genres(string genre);
    }
}
