using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IPlaylists : ISearchFilter<IPlaylists>, IGet<List<Models.Playlist>>
    {
    }
}
