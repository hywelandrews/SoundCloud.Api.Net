using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.TracksExclusive
{
    internal class TracksExclusive : ResourceBase<List<Models.Track>, ITracksExclusive>, ITracksExclusive
    {
        internal TracksExclusive(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.TracksExclusive;
        }
    }
}
