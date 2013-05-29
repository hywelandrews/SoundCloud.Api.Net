using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface ITracks : ISearch<ITracks>, IGet<List<Models.Track>>
    {
    }
}
