using System;

namespace SoundCloud.Api.Net.Resources
{
    public interface IPut<out T>
    {
        T Put();
        void PutAsync(Action<T> callback);
    }
}
