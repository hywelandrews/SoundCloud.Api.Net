using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Groups
{
    internal class Groups : ResourceBase<List<Models.Group>, IGroups>, IGroups
    {
        internal Groups(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Groups;
        }

        internal Groups(ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request.Resource = Uri.Groups;
        } 
    }
}
