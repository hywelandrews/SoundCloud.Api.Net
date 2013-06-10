using SoundCloud.Api.Net.Resources.Comment;
using SoundCloud.Api.Net.Resources.Comments;
using SoundCloud.Api.Net.Resources.Favorite;
using SoundCloud.Api.Net.Resources.Favorites;
using SoundCloud.Api.Net.Resources.SharedToEmails;
using SoundCloud.Api.Net.Resources.SharedToUsers;

namespace SoundCloud.Api.Net.Resources.Track
{
    public interface ITrack : IGet<Models.Track>, IPutWithModel<Models.Track>, IDelete
    {
        IComments Comments();
        IComment Comment(int id);
        IFavorites Favorites();
        IFavorite Favorite(int userId);
        ISharedToUsers SharedToUsers();
        ISharedToEmails SharedToEmails();
    }
}
