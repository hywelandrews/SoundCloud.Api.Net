using System.Collections.Generic;
using SoundCloud.Api.Net.Resources.Filters;

namespace SoundCloud.Api.Net.Resources.Playlists
{
    public interface IPlaylists : ISearchFilter<IPlaylists>, IGet<List<Models.Playlist>>
    {
    }
}
