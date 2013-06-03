using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface ITagsFilter<out T>
    {
        T Tags(IEnumerable<string> tags);
    }
}
