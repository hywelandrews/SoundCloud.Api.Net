using RestSharp;

namespace SoundCloud.Api.Net.Exceptions
{
    public class ResourceForbidden : BaseException
    {
        public ResourceForbidden(IRestRequest request, string errorMessage)
            : base(request, errorMessage)
        {
        }
    }
}
