using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Connections
{
    internal class Connections : ResourceBase<List<Models.Connection>, IConnections>, IConnections
    {
        internal Connections(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Connections;
        }
    }
}
