﻿using System;
using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources
{
    internal abstract class ResourceBase<T, TR> : IResource<T> where T:new() where TR:class
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
            return _soundCloudApi.Execute(this);
        }

        public void GetAsync(Action<T> callback)
        {
           Request.Method = Method.GET;
           _soundCloudApi.ExecuteAsync(this, callback);
        }

        public TR Search(string term)
        {
            Request.AddParameter(QueryParameter.Search, term, ParameterType.GetOrPost);
            return this as TR;
        }

        public TR Tags(IEnumerable<string> tags)
        {
            Request.AddParameter(QueryParameter.Tags, string.Join(",", tags), ParameterType.GetOrPost);
            return this as TR;
        }

        public TR Filter(Filters.Filters filter)
        {
            Request.AddParameter(QueryParameter.Filter, filter.ToString(), ParameterType.GetOrPost);
            return this as TR;
        }

        public TR License(string license)
        {
            Request.AddParameter(QueryParameter.License, license, ParameterType.GetOrPost);
            return this as TR;
        }

        public TR BpmFrom(double value)
        {
            Request.AddParameter(QueryParameter.BpmFrom, value, ParameterType.GetOrPost);
            return this as TR;
        }

        public TR BpmTo(double value)
        {
            Request.AddParameter(QueryParameter.BpmTo, value, ParameterType.GetOrPost);
            return this as TR;
        }
    }
}
