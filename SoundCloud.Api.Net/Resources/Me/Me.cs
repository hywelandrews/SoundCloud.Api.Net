using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Activities;
using SoundCloud.Api.Net.Resources.Comment;
using SoundCloud.Api.Net.Resources.Comments;
using SoundCloud.Api.Net.Resources.Connection;
using SoundCloud.Api.Net.Resources.Connections;
using SoundCloud.Api.Net.Resources.Favorite;
using SoundCloud.Api.Net.Resources.Favorites;
using SoundCloud.Api.Net.Resources.Follower;
using SoundCloud.Api.Net.Resources.Followers;
using SoundCloud.Api.Net.Resources.Following;
using SoundCloud.Api.Net.Resources.Followings;
using SoundCloud.Api.Net.Resources.Groups;
using SoundCloud.Api.Net.Resources.Playlists;
using SoundCloud.Api.Net.Resources.Tracks;
using SoundCloud.Api.Net.Resources.WebProfiles;

namespace SoundCloud.Api.Net.Resources.Me
{
    internal class Me : ResourceBase<Models.User, IMe>, IMe
    {
        private readonly ISoundCloudApiInternal _soundCloudApi;

        internal Me(ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = Uri.Me;
        }

        public IFavorite Favorite(int favoriteId)
        {
            return new Favorite.Favorite(Request, favoriteId, _soundCloudApi);
        }

        public IFavorites Favorites()
        {
            return new Favorites.Favorites(Request, _soundCloudApi);
        }

        public IFollowings Followings()
        {
            return new Followings.Followings(Request, _soundCloudApi);
        }

        public IFollowing Following(int followingId)
        {
            return new Following.Following(Request, followingId, _soundCloudApi);
        }

        public IFollowers Followers()
        {
            return new Followers.Followers(Request, _soundCloudApi);
        }

        public IFollower Follower(int followerId)
        {
            return new Follower.Follower(Request, followerId, _soundCloudApi);
        }

        public ITracks Tracks()
        {
            return new Tracks.Tracks(Request, _soundCloudApi);
        }

        public IPlaylists Playlists()
        {
            return new Playlists.Playlists(Request, _soundCloudApi);
        }

        public IComment Comment(int commentId)
        {
            return new Comment.Comment(Request, commentId, _soundCloudApi);
        }

        public IComments Comments()
        {
            return new Comments.Comments(Request, _soundCloudApi); 
        }

        public IGroups Groups()
        {
            return new Groups.Groups(Request, _soundCloudApi);
        }

        public IConnection Connection(int connectionId)
        {
            return new Connection.Connection(Request, connectionId, _soundCloudApi);
        }

        public IConnections Connections()
        {
            return new Connections.Connections(Request, _soundCloudApi);
        }

        public IActivities Activities()
        {
            return new Activities.Activities(Request, _soundCloudApi);
        }

        public IWebProfiles WebProfiles()
        {
            return new WebProfiles.WebProfiles(Request, _soundCloudApi);
        }
    }
}
