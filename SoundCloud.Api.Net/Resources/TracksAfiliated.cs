using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class TracksAfiliated : ResourceBase<List<Models.Track>, ITracksAfiliated>, ITracksAfiliated
    {
        internal TracksAfiliated(RestRequest request, ISoundCloudApiInternal _soundCloudApiInternal) : base(_soundCloudApiInternal)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.TracksAfiliated;
        }
    }
}
