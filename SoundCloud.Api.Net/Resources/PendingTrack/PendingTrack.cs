using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.PendingTrack
{
    internal class PendingTrack : ResourceBase<Models.Track, IPendingTrack>, IPendingTrack
    {
        public PendingTrack(RestRequest request, int trackId, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = string.Format(Uri.PendingTracks + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, trackId, ParameterType.UrlSegment);
        }
    }
}
