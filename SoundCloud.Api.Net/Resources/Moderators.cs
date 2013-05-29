using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Moderators : ResourceBase<List<Models.User>, IModerators>, IModerators
    {
        internal Moderators(RestRequest request, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Moderators;
        }
    }
}
