using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.TracksAfiliated
{
    internal class TracksAfiliated : ResourceBase<List<Models.Track>, ITracksAfiliated>, ITracksAfiliated
    {
        internal TracksAfiliated(RestRequest request, ISoundCloudApiInternal soundCloudApiInternal) : base(soundCloudApiInternal)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.TracksAfiliated;
        }
    }
}
