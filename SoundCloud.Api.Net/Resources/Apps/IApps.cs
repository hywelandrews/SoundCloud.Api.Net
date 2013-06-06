using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Apps
{
    public interface IApps : IResource<List<Models.App>>, IGet<List<Models.App>>
    {
    }
}
