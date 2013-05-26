using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Playlist : ResourceBase<Models.Playlist>
    {
        public Playlist(RestRequest request, string playlistId)
        {
            Request = request;
            Request.Resource = string.Format(Uri.Playlists + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, playlistId, ParameterType.UrlSegment);
        }

        public ISharedToUsers SharedToUsers()
        {
            return new SharedToUsers(Request);
        }

        public ISharedToEmails SharedToEmails()
        {
            return new SharedToEmails(Request);
        }
    }
}
