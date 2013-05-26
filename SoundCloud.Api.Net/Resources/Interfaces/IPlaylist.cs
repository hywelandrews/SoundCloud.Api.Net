namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IPlaylist : IGet<Models.Playlist>
    {
        ISharedToUsers SharedToUsers();
        ISharedToEmails SharedToEmails();
    }
}
