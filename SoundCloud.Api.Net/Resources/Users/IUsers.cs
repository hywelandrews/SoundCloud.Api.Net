using System.Collections.Generic;
using SoundCloud.Api.Net.Resources.Filters;

namespace SoundCloud.Api.Net.Resources.Users
{
    public interface IUsers : IResource<List<Models.User>>, ISearchFilter<IUsers>, IGet<List<Models.User>>
    {
    }
}
