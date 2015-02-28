using System;

namespace SoundCloud.Api.Net.Resources
{
    public interface IPost<T>
    {
        T Post(T model);
        void PostAsync(T model, Action<T> callback);
    }
}