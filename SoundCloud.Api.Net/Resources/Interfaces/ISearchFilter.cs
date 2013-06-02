namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface ISearchFilter<out T>
    {
        T Search(string term);
    }
}
