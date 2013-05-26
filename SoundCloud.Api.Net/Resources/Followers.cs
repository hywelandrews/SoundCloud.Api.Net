using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Followers : ResourceBase<List<Models.User>>, IFollowers
    {
        internal Followers(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Followers;
        }
    }
}
