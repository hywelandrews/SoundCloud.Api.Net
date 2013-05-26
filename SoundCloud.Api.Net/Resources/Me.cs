using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Me : ResourceBase<Models.User>, IMe
    {
        private readonly ISoundCloudApiInternal _soundCloudApi;

        internal Me(ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = Uri.Me;
        }

        public IFollowings Followings()
        {
            return new Followings(Request, _soundCloudApi);
        }

        public IFollowing Following(string followingId)
        {
            return new Following(Request, followingId, _soundCloudApi);
        }

        public IFollowers Followers()
        {
            return new Followers(Request, _soundCloudApi);
        }

        public IFollower Follower(string followerId)
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

        public IConnection Connection(int connectionId)
        {
            return new Connection(Request, connectionId, _soundCloudApi);
        }

        public IConnections Connections()
        {
            return new Connections(Request, _soundCloudApi);
        }

        public IActivities Activities()
        {
            return new Activities(Request, _soundCloudApi);
        }

        public IWebProfiles WebProfiles()
        {
            return new WebProfiles(Request, _soundCloudApi);
        }
    }
}
