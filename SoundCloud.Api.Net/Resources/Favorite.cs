using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Favorite : ResourceBase<Models.Track>, IFavorite
    {
        internal Favorite(RestRequest request, int userId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Favorites + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, userId, ParameterType.UrlSegment);
        }
    }
}
