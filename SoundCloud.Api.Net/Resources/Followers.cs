using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
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
