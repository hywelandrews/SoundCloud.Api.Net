using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Groups : ResourceBase<List<Models.Group>>, IGroups
    {
        internal Groups(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Groups;
        }
    }
}
