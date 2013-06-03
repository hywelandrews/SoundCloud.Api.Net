using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Contributors
{
    internal class Contributors : ResourceBase<List<Models.User>, IContributors>, IContributors
    {
        internal Contributors(RestRequest request, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Contributors;
        }
    }
}
