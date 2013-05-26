using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Playlist : ResourceBase<Models.Playlist>, IPlaylist
    {
        private readonly ISoundCloudApiInternal _soundCloudApi;

        public Playlist(int playlistId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = string.Format(Uri.Playlists + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, playlistId, ParameterType.UrlSegment);
        }

        public ISharedToUsers SharedToUsers()
        {
            return new SharedToUsers(Request, _soundCloudApi);
        }

        public ISharedToEmails SharedToEmails()
        {
            return new SharedToEmails(Request, _soundCloudApi);
        }
    }
}
