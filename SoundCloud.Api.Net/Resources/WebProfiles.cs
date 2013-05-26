using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class WebProfiles : ResourceBase<List<Models.WebProfile>>, IWebProfiles
    {
        internal WebProfiles(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.WebProfiles;
        }
    }
}
