using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IPlaylists : ISearch<IPlaylists>, IGet<List<Models.Playlist>>
    {
    }
}
