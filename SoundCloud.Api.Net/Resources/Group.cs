using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Group : ResourceBase<Models.Group>, IGroup
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
            return new Moderators(Request, _soundCloudApi);
        }

        public IMembers Members()
        {
            return new Members(Request, _soundCloudApi);
        }

        public IContributors Contributors()
        {
            return new Contributors(Request, _soundCloudApi);
        }

        public IUsers Users()
        {
            return new Users(Request, _soundCloudApi);
        }

        public ITracks Tracks()
        {
            return new Tracks(Request, _soundCloudApi);
        }

        public IPendingTracks PendingTracks()
        {
            return new PendingTracks(Request, _soundCloudApi);
        }

        public IPendingTrack PendingTrack(int trackId)
        {
            return new PendingTrack(Request, trackId, _soundCloudApi);
        }
    }
}
