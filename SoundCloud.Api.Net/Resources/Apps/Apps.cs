using System.Collections.Generic;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Apps
{
    internal class Apps : ResourceBase<List<Models.App>, IApps>, IApps
    {
        public Apps(ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request.Resource = Uri.Apps;
        }
    }
}
