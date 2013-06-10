using RestSharp;

namespace SoundCloud.Api.Net.Exceptions
{
    public class ResourceNotFound : BaseException
    {
        public ResourceNotFound(IRestRequest request, string errorMessage) : base(request, errorMessage)
        {
        }
    }
}
