using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.SharedToEmails;
using SoundCloud.Api.Net.Resources.SharedToUsers;

namespace SoundCloud.Api.Net.Resources.Playlist
{
    internal class Playlist : ResourceBase<Models.Playlist, IPlaylist>, IPlaylist
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
            return new SharedToUsers.SharedToUsers(Request, _soundCloudApi);
        }

        public ISharedToEmails SharedToEmails()
        {
            return new SharedToEmails.SharedToEmails(Request, _soundCloudApi);
        }
    }
}
