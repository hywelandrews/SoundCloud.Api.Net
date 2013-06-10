using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.WebProfile
{
    internal class WebProfile : ResourceBase<Models.WebProfile, IWebProfile>, IWebProfile
    {
        internal WebProfile(RestRequest request, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.WebProfiles;
        }
    }
}
