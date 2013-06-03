using RestSharp;

namespace SoundCloud.Api.Net.Resources
{
    public interface IResource<T>
    {
        RestRequest GetRequest();
        void SetRequest(RestRequest request);
    }
}
