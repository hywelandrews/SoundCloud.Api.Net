using System;

namespace SoundCloud.Api.Net.Resources
{
    public interface IDelete<out T> where T : new()
    {
        void Delete();
        void DeleteAsync(Action<T> callback);
    }
}
