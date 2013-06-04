using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface ITypesFilter<out T>
    {
        T Types(IEnumerable<TypeFilter> list);
    }
}
