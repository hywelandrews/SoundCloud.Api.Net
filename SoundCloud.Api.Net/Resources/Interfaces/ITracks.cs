using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface ITracks : IResource<List<Models.Track>>, ISearchFilter<ITracks>, ITagsFilter<ITracks>, IGet<List<Models.Track>>
    {
    }
}
