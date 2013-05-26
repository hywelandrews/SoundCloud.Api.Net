using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Me : ResourceBase<User>
    {
        public Me()
        {
            Request.Resource = Uri.Me;
        }

        public IFollowings Followings()
        {
            return new Followings(Request);
        }

        public IFollowing Following(string followingId)
        {
            return new Following(Request, followingId);
        }

        public IFollowers Followers()
        {
            return new Followers(Request);
        }

        public IFollower Follower(string followerId)
        {
            return new Follower(Request, followerId);
        }

        public ITracks Tracks()
        {
            return new Tracks(Request);
        }

        public IPlaylists Playlists()
        {
            return new Playlists(Request);
        }

        public IComment Comment(int commentId)
        {
            return new Comment(Request, commentId);
        }

        public IComments Comments()
        {
            return new Comments(Request); 
        }

        public IGroups Groups()
        {
            return new Groups(Request);
        }

        public IConnection Connection(int connectionId)
        {
            return new Connection(Request, connectionId);
        }

        public IConnections Connections()
        {
            return new Connections(Request);
        }

        public IActivities Activities()
        {
            return new Activities(Request);
        }

        public IWebProfiles WebProfiles()
        {
            return new WebProfiles(Request);
        }
    }
}
