using System.Collections.Generic;
using SoundCloud.Api.Net.Resources.Filters;

namespace SoundCloud.Api.Net.Resources.Groups
{
    public interface IGroups : ISearchFilter<IGroups>, IGet<List<Models.Group>>
    {
    }
}
