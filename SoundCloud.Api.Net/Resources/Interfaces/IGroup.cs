namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IGroup : IGet<Models.Group>
    {
        IModerators Moderators();
        IMembers Members();
        IContributors Contributors();
        IUsers Users();
        ITracks Tracks();
        IPendingTracks PendingTracks();
    }
}
