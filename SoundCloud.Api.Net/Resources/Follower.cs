using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Follower : ResourceBase<Models.User>, IFollower
    {
        internal Follower(RestRequest request, string followerId)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Followers + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, followerId, ParameterType.UrlSegment);
        }
    }
}
