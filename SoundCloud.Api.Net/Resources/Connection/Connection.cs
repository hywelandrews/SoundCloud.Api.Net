using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Connection
{
    internal class Connection : ResourceBase<Models.Connection, IConnection>, IConnection
    {
        internal Connection(RestRequest request, int connectionId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request.Resource = string.Format(Uri.Connections + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, connectionId, ParameterType.UrlSegment);
        }
    }
}
