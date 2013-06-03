using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface IGenresFilter<out T>
    {
        T Genres(IEnumerable<string> list);
    }
}
