using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface ITracks : ISearchFilter<ITracks>, ITagsFilter<ITracks>, IGet<List<Models.Track>>
    {
    }
}
