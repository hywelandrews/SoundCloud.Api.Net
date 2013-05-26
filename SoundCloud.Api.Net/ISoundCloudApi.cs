using System;
using System.Collections.Generic;
using SoundCloud.Api.Net.Resources;

namespace SoundCloud.Api.Net
{
    public interface ISoundCloudApi
    {
        T Execute<T>(ResourceBase<T> resource) where T : new();
        void ExecuteAsync<T>(ResourceBase<T> resource, Action<T> callback) where T : new();
        List<T> Execute<T>(IEnumerable<ResourceBase<T>> resources) where T : new();
        void ExecuteAsync<T>(IEnumerable<ResourceBase<T>> resources, Action<List<T>> callback ) where T : new();
    }
}
