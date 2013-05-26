using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Track : ResourceBase<Models.Track>, ITrack
    {
        public Track(int trackId)
        {
            Request.Resource = string.Format(Uri.Tracks + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, trackId, ParameterType.UrlSegment);
        }

        public IComments Comments()
        {
            return new Comments(Request);
        }

        public IComment Comments(int id)
        {
            return new Comment(Request, id);
        }

        public IFavorites Favorites()
        {
            return new Favorites(Request);
        }

        public IFavorite Favorite(int id)
        {
            return new Favorite(Request, id);
        }

        public ISharedToUsers SharedTo()
        {
            return new SharedToUsers(Request);
        }
    }
}
