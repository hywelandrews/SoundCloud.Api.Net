using RestSharp;

namespace SoundCloud.Api.Net.Exceptions
{
    internal class ResourceBadRequest : BaseException
    {
        public ResourceBadRequest(IRestRequest request, string errorMessage)
            : base(request, errorMessage)
        {
        }
    }
}
