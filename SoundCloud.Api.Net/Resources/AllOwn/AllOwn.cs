using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.AllOwn
{
    internal class AllOwn : ResourceBase<List<Models.Track>, IAllOwn>, IAllOwn
    {
        internal AllOwn(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.AllOwn;
        }
    }
}
