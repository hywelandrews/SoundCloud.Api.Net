using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Activities : ResourceBase<List<Activity>>, IActivities
    {
        internal Activities(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Activities;
        }

        public TracksAfiliated TracksAfiliated()
        {
            return new TracksAfiliated(Request);
        }

        public TracksExclusive TracksExclusive()
        {
            return new TracksExclusive(Request);
        }

        public AllOwn AllOwn()
        {
            return new AllOwn(Request);
        }
    }
}
