using System;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net
{
    internal interface ISoundCloudApiInternal
    {
        T Execute<T>(IResource<T> resource) where T : new();
        void ExecuteAsync<T>(IResource<T> resource, Action<T> callback) where T : new();
    }
}
