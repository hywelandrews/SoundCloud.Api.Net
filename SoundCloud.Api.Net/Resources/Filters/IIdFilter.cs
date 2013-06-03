using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface IIdFilter<out T>
    {
        T Ids(IEnumerable<int> list);
    }
}
