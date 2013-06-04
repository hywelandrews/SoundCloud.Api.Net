using System.Collections.Generic;
using SoundCloud.Api.Net.Resources.Filters;

namespace SoundCloud.Api.Net.Resources.Playlists
{
    public interface IPlaylists : IResource<List<Models.Playlist>>, ISearchFilter<IPlaylists>, IGet<List<Models.Playlist>>
    {
    }
}
