using SoundCloud.Api.Net.Resources.SharedToEmails;
using SoundCloud.Api.Net.Resources.SharedToUsers;

namespace SoundCloud.Api.Net.Resources.Playlist
{
    public interface IPlaylist : IResource<Models.Playlist>, IGet<Models.Playlist>
    {
        ISharedToUsers SharedToUsers();
        ISharedToEmails SharedToEmails();
    }
}
