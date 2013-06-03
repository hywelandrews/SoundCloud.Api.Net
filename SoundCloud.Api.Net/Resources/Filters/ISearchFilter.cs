namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface ISearchFilter<out T>
    {
        T Search(string term);
    }
}
