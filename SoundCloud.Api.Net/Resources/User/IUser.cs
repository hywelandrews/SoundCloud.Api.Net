using SoundCloud.Api.Net.Resources.Comment;
using SoundCloud.Api.Net.Resources.Comments;
using SoundCloud.Api.Net.Resources.Favorite;
using SoundCloud.Api.Net.Resources.Favorites;
using SoundCloud.Api.Net.Resources.Follower;
using SoundCloud.Api.Net.Resources.Followers;
using SoundCloud.Api.Net.Resources.Following;
using SoundCloud.Api.Net.Resources.Followings;
using SoundCloud.Api.Net.Resources.Groups;
using SoundCloud.Api.Net.Resources.Playlists;
using SoundCloud.Api.Net.Resources.Tracks;
using SoundCloud.Api.Net.Resources.WebProfile;
using SoundCloud.Api.Net.Resources.WebProfiles;

namespace SoundCloud.Api.Net.Resources.User
{
    public interface IUser : IResource<Models.User>, IGet<Models.User>
    {
        IFollowings Followings();
        IFollowing Following(int followingId);
        IFollowers Followers();
        IFollower Follower(int followerId);
        ITracks Tracks();
        IPlaylists Playlists();
        IComment Comment(int commentId);
        IComments Comments();
        IFavorite Favorite(int favoriteId);
        IFavorites Favorites();
        IGroups Groups();
        IWebProfile WebProfile(int webProfileId);
        IWebProfile WebProfile();
        IWebProfiles WebProfiles();
    }
}
