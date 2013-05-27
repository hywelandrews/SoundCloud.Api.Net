using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class User : ResourceBase<Models.User>, IUser
    {
        private readonly ISoundCloudApiInternal _soundCloudApi;

        internal User(ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = Uri.Users + "me";
        }

        internal User(int userId, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = string.Format(Uri.Users + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, userId, ParameterType.UrlSegment);
        }

        public IFollowings Followings()
        {
            return new Followings(Request, _soundCloudApi);
        }

        public IFollowing Following(int followingId)
        {
            return new Following(Request, followingId, _soundCloudApi);
        }

        public IFollowers Followers()
        {
            return new Followers(Request, _soundCloudApi);
        }

        public IFollower Follower(int followerId)
        {
            return new Follower(Request, followerId, _soundCloudApi);
        }

        public ITracks Tracks()
        {
            return new Tracks(Request, _soundCloudApi);
        }

        public IPlaylists Playlists()
        {
            return new Playlists(Request, _soundCloudApi);
        }

        public IComment Comment(int commentId)
        {
            return new Comment(Request, commentId, _soundCloudApi);
        }

        public IComments Comments()
        {
            return new Comments(Request, _soundCloudApi); 
        }

        public IGroups Groups()
        {
            return new Groups(Request, _soundCloudApi);
        }

        public IFavorite Favorite(int favoriteId)
        {
            return new Favorite(Request, favoriteId, _soundCloudApi);
        }

        public IFavorites Favorites()
        {
            return new Favorites(Request, _soundCloudApi);
        }

        public IWebProfiles WebProfiles()
        {
            return new WebProfiles(Request, _soundCloudApi);
        }
    }
}
