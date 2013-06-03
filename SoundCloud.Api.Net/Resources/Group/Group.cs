using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Contributors;
using SoundCloud.Api.Net.Resources.Members;
using SoundCloud.Api.Net.Resources.Moderators;
using SoundCloud.Api.Net.Resources.PendingTrack;
using SoundCloud.Api.Net.Resources.PendingTracks;
using SoundCloud.Api.Net.Resources.Tracks;
using SoundCloud.Api.Net.Resources.Users;

namespace SoundCloud.Api.Net.Resources.Group
{
    internal class Group : ResourceBase<Models.Group, IGroup>, IGroup
    {
        private readonly ISoundCloudApiInternal _soundCloudApi;

        internal Group(int groupId, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = Request.Resource + string.Format(Uri.Groups + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, groupId, ParameterType.UrlSegment);
        }

        public IModerators Moderators()
        {
            return new Moderators.Moderators(Request, _soundCloudApi);
        }

        public IMembers Members()
        {
            return new Members.Members(Request, _soundCloudApi);
        }

        public IContributors Contributors()
        {
            return new Contributors.Contributors(Request, _soundCloudApi);
        }

        public IUsers Users()
        {
            return new Users.Users(Request, _soundCloudApi);
        }

        public ITracks Tracks()
        {
            return new Tracks.Tracks(Request, _soundCloudApi);
        }

        public IPendingTracks PendingTracks()
        {
            return new PendingTracks.PendingTracks(Request, _soundCloudApi);
        }

        public IPendingTrack PendingTrack(int trackId)
        {
            return new PendingTrack.PendingTrack(Request, trackId, _soundCloudApi);
        }
    }
}
