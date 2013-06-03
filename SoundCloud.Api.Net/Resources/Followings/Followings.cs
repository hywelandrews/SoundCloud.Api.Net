using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Followings
{
    internal class Followings : ResourceBase<List<Models.User>, IFollowings>, IFollowings
    {
        internal Followings(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Followings;
        }
    }
}
