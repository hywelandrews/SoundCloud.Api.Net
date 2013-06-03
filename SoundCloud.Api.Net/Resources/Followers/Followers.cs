using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Followers
{
    internal class Followers : ResourceBase<List<Models.User>, IFollowers>, IFollowers
    {
        internal Followers(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Followers;
        }
    }
}
