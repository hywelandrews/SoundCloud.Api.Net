using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Connection : ResourceBase<Models.Connection>, IConnection
    {
        internal Connection(RestRequest request, int connectionId)
        {
            Request.Resource = string.Format(Uri.Connections + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, connectionId, ParameterType.UrlSegment);
        }
    }
}
