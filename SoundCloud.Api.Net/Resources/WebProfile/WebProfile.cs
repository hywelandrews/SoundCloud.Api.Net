using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.WebProfile
{
    internal class WebProfile : ResourceBase<Models.WebProfile, IWebProfile>, IWebProfile
    {
        internal WebProfile(RestRequest request, int webProfileId, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.WebProfiles + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, webProfileId, ParameterType.UrlSegment);
        }

        internal WebProfile(RestRequest request, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.WebProfiles;
        }
    }
}
