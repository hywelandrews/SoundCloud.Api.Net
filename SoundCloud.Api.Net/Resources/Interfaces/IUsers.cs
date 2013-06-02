using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IUsers : IResource<List<Models.User>>, ISearchFilter<IUsers>, IGet<List<Models.User>>
    {
    }
}
