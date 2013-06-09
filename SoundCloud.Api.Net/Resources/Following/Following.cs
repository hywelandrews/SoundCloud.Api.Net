using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Following
{
    internal class Following : ResourceBase<Models.User, IFollowing>, IFollowing
    {
        internal Following(RestRequest request, int followingId, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Followings + "{{{0}}}", UrlParameter.followingId);
            Request.AddParameter(UrlParameter.followingId, followingId, ParameterType.UrlSegment);
        }
    }
}
