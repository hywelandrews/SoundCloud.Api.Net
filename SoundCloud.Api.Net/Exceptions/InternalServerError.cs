using RestSharp;

namespace SoundCloud.Api.Net.Exceptions
{
    class InternalServerError : BaseException
    {
        public InternalServerError(IRestRequest request, string errorMessage) : base(request, errorMessage)
        {
        }
    }
}
