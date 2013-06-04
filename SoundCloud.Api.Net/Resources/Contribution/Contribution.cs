using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Contribution
{
    internal class Contribution : ResourceBase<Models.Track, IContribution>, IContribution
    {
        internal Contribution(RestRequest request, int contributionId, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Contributions + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, contributionId, ParameterType.UrlSegment);
        }
    }
}
