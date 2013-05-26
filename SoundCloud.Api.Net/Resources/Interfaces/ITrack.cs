namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface ITrack : IGet<Models.Track>
    {
        IComments Comments();
        IComment Comment(int id);
        IFavorites Favorites();
        IFavorite Favorite(int userId);
        ISharedToUsers SharedToUsers();
        ISharedToEmails SharedToEmails();
    }
}
