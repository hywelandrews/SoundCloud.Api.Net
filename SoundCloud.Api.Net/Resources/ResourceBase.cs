using System;
using RestSharp;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    public abstract class ResourceBase<T> : IGet<T> where T:new()
    {
        protected RestRequest Request = new RestRequest();

        protected ResourceBase()
        {
            Request.RequestFormat = DataFormat.Json;
        }
    
        public RestRequest GetRequest()
        {
            return Request;
        }

        public void SetRequest(RestRequest request)
        {
            Request = request;
        }

        public T Get(ISoundCloudApi soundCloudApi)
        {
            Request.Method = Method.GET;
            return soundCloudApi.Execute(this);
        }

        public void GetAsync(ISoundCloudApi soundCloudApi, Action<T> callback)
        {
           Request.Method = Method.GET;
           soundCloudApi.ExecuteAsync(this, callback);
        }
    }
}
