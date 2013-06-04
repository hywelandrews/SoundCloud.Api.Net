using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Contributions
{
    internal class Contributions : ResourceBase<List<Models.Track>, IContributions>, IContributions
    {
        internal Contributions(RestRequest request, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request.Resource = Request.Resource + Uri.Contributions;
        } 
    }

}
