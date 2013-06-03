using System;
using System.Collections.Generic;
using SoundCloud.Api.Net.Resources;
using SoundCloud.Api.Net.Resources.Group;
using SoundCloud.Api.Net.Resources.Playlist;
using SoundCloud.Api.Net.Resources.Track;
using SoundCloud.Api.Net.Resources.Tracks;
using SoundCloud.Api.Net.Resources.User;
using SoundCloud.Api.Net.Resources.Users;

namespace SoundCloud.Api.Net
{
    public interface ISoundCloudApi
    {
        List<T> Execute<T>(IEnumerable<IResource<T>> resources) where T : new();
        void ExecuteAsync<T>(IEnumerable<IResource<T>> resources, Action<List<T>> callback) where T : new();
        IUser User();
        IUser User(int userId);
        IUsers Users();
        ITrack Track(int trackId);
        ITracks Tracks();
        IPlaylist Playlist(int playlistId);
        IGroup Group(int groupId);
    }
}
