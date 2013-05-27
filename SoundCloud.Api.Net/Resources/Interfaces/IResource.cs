using RestSharp;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IResource<T>
    {
        RestRequest GetRequest();
        void SetRequest(RestRequest request);
    }
}
