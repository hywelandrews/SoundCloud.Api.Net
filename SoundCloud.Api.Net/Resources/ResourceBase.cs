using System;
using RestSharp;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal abstract class ResourceBase<T> : IResource where T:new()
    {
        protected RestRequest Request = new RestRequest();
        private readonly ISoundCloudApiInternal _soundCloudApi;

        protected ResourceBase(ISoundCloudApiInternal soundCloudApi)
        {
            Request.RequestFormat = DataFormat.Json;
            _soundCloudApi = soundCloudApi;
        }
    
        public RestRequest GetRequest()
        {
            return Request;
        }

        public void SetRequest(RestRequest request)
        {
            Request = request;
        }

        public T Get()
        {
            Request.Method = Method.GET;
            return _soundCloudApi.Execute<T>(this);
        }

        public void GetAsync(Action<T> callback)
        {
           Request.Method = Method.GET;
           _soundCloudApi.ExecuteAsync<T>(this, callback);
        }
    }
}
