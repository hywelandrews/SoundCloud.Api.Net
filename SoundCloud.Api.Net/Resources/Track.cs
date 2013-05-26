using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Track : ResourceBase<Models.Track>, ITrack
    {
        private readonly ISoundCloudApiInternal _soundCloudApi;

        public Track(int trackId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = string.Format(Uri.Tracks + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, trackId, ParameterType.UrlSegment);
        }

        public IComments Comments()
        {
            return new Comments(Request, _soundCloudApi);
        }

        public IComment Comment(int id)
        {
            return new Comment(Request, id, _soundCloudApi);
        }

        public IFavorites Favorites()
        {
            return new Favorites(Request, _soundCloudApi);
        }

        public IFavorite Favorite(int userId)
        {
            return new Favorite(Request, userId, _soundCloudApi);
        }

        public ISharedToUsers SharedToUsers()
        {
            return new SharedToUsers(Request, _soundCloudApi);
        }

        public ISharedToEmails SharedToEmails()
        {
            return new SharedToEmails(Request, _soundCloudApi);
        }
    }
}
