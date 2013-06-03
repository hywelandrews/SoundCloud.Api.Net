using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.PendingTracks
{
    internal class PendingTracks : ResourceBase<List<Models.Track>, IPendingTracks>, IPendingTracks
    {
        internal PendingTracks(RestRequest request, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.PendingTracks;
        }
    }
}
