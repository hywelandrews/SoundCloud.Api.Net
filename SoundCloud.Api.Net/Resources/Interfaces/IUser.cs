namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IUser : IResource, IGet<Models.User>
    {
        IFollowings Followings();
        IFollowing Following(string followingId);
        IFollowers Followers();
        IFollower Follower(string followerId);
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
