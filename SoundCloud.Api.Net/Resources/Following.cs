using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Following : ResourceBase<Models.User>, IFollowing
    {
        internal Following(RestRequest request, string followingId)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Followings + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, followingId, ParameterType.UrlSegment);
        }
    }
}
