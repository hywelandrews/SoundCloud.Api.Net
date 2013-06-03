using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.WebProfiles
{
    internal class WebProfiles : ResourceBase<List<Models.WebProfile>, IWebProfiles>, IWebProfiles
    {
        internal WebProfiles(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.WebProfiles;
        }
    }
}
