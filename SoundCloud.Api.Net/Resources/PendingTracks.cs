using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
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
