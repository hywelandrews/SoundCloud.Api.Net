using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.WebProfiles
{
    public interface IWebProfiles : IGet<List<Models.WebProfile>>, IPut<List<Models.WebProfile>>, IDelete<List<Models.WebProfile>>
    {
    }
}
