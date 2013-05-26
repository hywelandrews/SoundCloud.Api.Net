using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Connections : ResourceBase<List<Models.Connection>>, IConnections
    {
        internal Connections(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Connections;
        }
    }
}
