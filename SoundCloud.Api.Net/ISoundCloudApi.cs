using System;
using System.Collections.Generic;
using SoundCloud.Api.Net.Resources.Interfaces;

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
        IPlaylist Playlist(int playlistId);
        IGroup Group(int groupId);
    }
}
