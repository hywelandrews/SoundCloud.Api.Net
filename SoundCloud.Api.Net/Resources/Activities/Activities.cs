using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.AllOwn;
using SoundCloud.Api.Net.Resources.TracksAfiliated;
using SoundCloud.Api.Net.Resources.TracksExclusive;

namespace SoundCloud.Api.Net.Resources.Activities
{
    internal class Activities : ResourceBase<List<Activity>, IActivities>, IActivities
    {
        private readonly ISoundCloudApiInternal _soundCloudApi;

        internal Activities(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request = request;
            Request.Resource = Request.Resource + Uri.Activities;
        }

        public ITracksAfiliated TracksAfiliated()
        {
            return new TracksAfiliated.TracksAfiliated(Request, _soundCloudApi);
        }

        public ITracksExclusive TracksExclusive()
        {
            return new TracksExclusive.TracksExclusive(Request, _soundCloudApi);
        }

        public IAllOwn AllOwn()
        {
            return new AllOwn.AllOwn(Request, _soundCloudApi);
        }
    }
}
