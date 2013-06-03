namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface ILicenseFilter<out T>
    {
        T License(string type);
    }
}
