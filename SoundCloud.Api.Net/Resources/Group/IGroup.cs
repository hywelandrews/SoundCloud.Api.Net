using SoundCloud.Api.Net.Resources.Contributors;
using SoundCloud.Api.Net.Resources.Members;
using SoundCloud.Api.Net.Resources.Moderators;
using SoundCloud.Api.Net.Resources.PendingTracks;
using SoundCloud.Api.Net.Resources.Tracks;
using SoundCloud.Api.Net.Resources.Users;

namespace SoundCloud.Api.Net.Resources.Group
{
    public interface IGroup : IResource<Models.Group>, IGet<Models.Group>
    {
        IModerators Moderators();
        IMembers Members();
        IContributors Contributors();
        IUsers Users();
        ITracks Tracks();
        IPendingTracks PendingTracks();
    }
}
