using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Playlists
{
    internal class Playlists : ResourceBase<List<Models.Playlist>, IPlaylists>, IPlaylists
    {
        internal Playlists(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Playlists;
        }
    }
}
