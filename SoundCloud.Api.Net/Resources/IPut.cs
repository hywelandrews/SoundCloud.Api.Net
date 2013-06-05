using System;

namespace SoundCloud.Api.Net.Resources
{
    public interface IPut<T>
    {
        T Put(T model);
        void PutAsync(T model, Action<T> callback);
    }
}
