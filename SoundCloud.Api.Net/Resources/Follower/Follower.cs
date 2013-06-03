using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Follower
{
    internal class Follower : ResourceBase<Models.User, IFollower>, IFollower
    {
        internal Follower(RestRequest request, int followerId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Followers + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, followerId, ParameterType.UrlSegment);
        }
    }
}
