using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Comment;
using SoundCloud.Api.Net.Resources.Comments;
using SoundCloud.Api.Net.Resources.Favorite;
using SoundCloud.Api.Net.Resources.Favorites;
using SoundCloud.Api.Net.Resources.SharedToEmails;
using SoundCloud.Api.Net.Resources.SharedToUsers;

namespace SoundCloud.Api.Net.Resources.Track
{
    internal class Track : ResourceBase<Models.Track, ITrack>, ITrack
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
            return new Comments.Comments(Request, _soundCloudApi);
        }

        public IComment Comment(int id)
        {
            return new Comment.Comment(Request, id, _soundCloudApi);
        }

        public IFavorites Favorites()
        {
            return new Favorites.Favorites(Request, _soundCloudApi);
        }

        public IFavorite Favorite(int userId)
        {
            return new Favorite.Favorite(Request, userId, _soundCloudApi);
        }

        public ISharedToUsers SharedToUsers()
        {
            return new SharedToUsers.SharedToUsers(Request, _soundCloudApi);
        }

        public ISharedToEmails SharedToEmails()
        {
            return new SharedToEmails.SharedToEmails(Request, _soundCloudApi);
        }
    }
}
