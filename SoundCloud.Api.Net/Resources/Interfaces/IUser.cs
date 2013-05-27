namespace SoundCloud.Api.Net.Resources.Interfaces
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
        IWebProfiles WebProfiles();
    }
}
