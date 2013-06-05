using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Comments
{
    public interface IComments : IResource<List<Models.Comment>>, IGet<List<Models.Comment>>
    {
    }
}
