using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class TracksExclusive: ResourceBase<List<Models.Track>>, ITracksExclusive
    {
        internal TracksExclusive(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.TracksExclusive;
        }
    }
}
