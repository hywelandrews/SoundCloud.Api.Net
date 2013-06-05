using System.Collections.Generic;
using SoundCloud.Api.Net.Resources.Filters;

namespace SoundCloud.Api.Net.Resources.Groups
{
    public interface IGroups : IResource<List<Models.Group>>, ISearchFilter<IGroups>, IGet<List<Models.Group>>
    {
    }
}
