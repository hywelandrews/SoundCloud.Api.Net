using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Followings : ResourceBase<List<Models.User>>, IFollowings
    {
        internal Followings(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Followings;
        }
    }
}
