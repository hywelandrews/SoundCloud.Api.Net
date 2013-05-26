using RestSharp;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IResource
    {
        RestRequest GetRequest();
        void SetRequest(RestRequest request);
    }
}
