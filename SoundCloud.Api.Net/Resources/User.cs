using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    public class User : ResourceBase<Models.User>, IUser
    {
        public User()
        {
            Request.Resource = Uri.Users + "me";
        }

        public User(int userId)
        {
            Request.Resource = string.Format(Uri.Users + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, userId, ParameterType.UrlSegment);
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

        public IWebProfiles WebProfiles()
        {
            return new WebProfiles(Request);
        }
    }
}
