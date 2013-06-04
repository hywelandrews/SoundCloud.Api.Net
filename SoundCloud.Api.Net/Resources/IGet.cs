using System;

namespace SoundCloud.Api.Net.Resources
{
    public interface IGet<out T> where T : new()
    {
        T Get();
        void GetAsync(Action<T> callback);
    }
}
