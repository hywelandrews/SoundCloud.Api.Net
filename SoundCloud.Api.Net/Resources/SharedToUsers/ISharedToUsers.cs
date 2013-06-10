using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.SharedToUsers
{
    public interface ISharedToUsers : IGet<List<Models.User>>, IPut<List<Models.User>>, IDelete
    {
    }
}
