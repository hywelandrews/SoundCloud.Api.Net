namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface ILicenseFilter<out T>
    {
        T License(string type);
    }
}
