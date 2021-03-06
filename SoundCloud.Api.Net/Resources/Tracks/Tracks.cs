﻿using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Tracks
{
    internal class Tracks : ResourceBase<List<Models.Track>, ITracks>, ITracks
    {
        internal Tracks(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Tracks;
        }

        internal Tracks(ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request.Resource = Uri.Tracks;
        } 
    }
}
