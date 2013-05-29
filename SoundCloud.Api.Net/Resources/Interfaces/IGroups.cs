using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IGroups : ISearch<IGroups>, IGet<List<Models.Group>>
    {
    }
}
