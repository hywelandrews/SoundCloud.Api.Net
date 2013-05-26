using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Activities : ResourceBase<List<Activity>>, IActivities
    {
        private ISoundCloudApiInternal _soundCloudApi;

        internal Activities(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base (soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request = request;
            Request.Resource = Request.Resource + Uri.Activities;
        }

        public TracksAfiliated TracksAfiliated()
        {
            return new TracksAfiliated(Request, _soundCloudApi);
        }

        public TracksExclusive TracksExclusive()
        {
            return new TracksExclusive(Request, _soundCloudApi);
        }

        public AllOwn AllOwn()
        {
            return new AllOwn(Request, _soundCloudApi);
        }
    }
}
