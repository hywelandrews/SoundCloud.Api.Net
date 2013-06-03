using System;

namespace SoundCloud.Api.Net.Resources.Filters
{
    public interface ICreatedFilter<out T>
    {
        T CreatedFrom(DateTime date);
        T CreatedTo(DateTime date);
    }
}
