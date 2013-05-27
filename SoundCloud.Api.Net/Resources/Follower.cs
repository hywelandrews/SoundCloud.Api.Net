﻿using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Follower : ResourceBase<Models.User>, IFollower
    {
        internal Follower(RestRequest request, int followerId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Followers + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, followerId, ParameterType.UrlSegment);
        }
    }
}
