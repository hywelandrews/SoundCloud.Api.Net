namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface ISearch<out T>
    {
        T Search(string term);
    }
}
