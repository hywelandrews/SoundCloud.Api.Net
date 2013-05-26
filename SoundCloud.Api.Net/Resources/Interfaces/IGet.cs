using System;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IGet<T> where T : new()
    {
        T Get(ISoundCloudApi soundCloudApi);
        void GetAsync(ISoundCloudApi soundCloudApi, Action<T> callback);
    }
}
