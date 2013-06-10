using RestSharp;

namespace SoundCloud.Api.Net.Exceptions
{
    internal class Unauthorized : BaseException
    {
        public Unauthorized(IRestRequest request, string errorMessage)
            : base(request, errorMessage)
        {
        }
    }
}
