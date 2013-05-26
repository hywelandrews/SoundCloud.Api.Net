using System;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IGet<T> where T : new()
    {
        T Get();
        void GetAsync(Action<T> callback);
    }
}
