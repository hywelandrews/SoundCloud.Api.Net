using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Favorites
{
    internal class Favorites : ResourceBase<List<Models.Track>, IFavorites>, IFavorites
    {
        internal Favorites(RestRequest request, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Favorites;
        }
    }
}
