using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Favorites : ResourceBase<List<Models.Track>>, IFavorites
    {
        internal Favorites(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Favorites;
        }
    }
}
