using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Playlists : ResourceBase<List<Models.Playlist>>, IPlaylists
    {
        internal Playlists(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Playlists;
        }
    }
}
