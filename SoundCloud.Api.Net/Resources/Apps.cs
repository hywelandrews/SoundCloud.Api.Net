﻿using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources
{
    internal class Apps : ResourceBase<Models.App>
    {
        private ISoundCloudApiInternal _soundCloudApi;
        public Apps(int appId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = string.Format(Uri.Apps + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, appId, ParameterType.UrlSegment);
        }

        public Tracks Tracks()
        {
            return new Tracks(Request, _soundCloudApi);
        }
    }
}
