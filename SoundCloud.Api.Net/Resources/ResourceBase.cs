﻿using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using RestSharp.Serializers;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Filters;

namespace SoundCloud.Api.Net.Resources
{
    internal abstract class ResourceBase<T, TR> : IResource<T> where T : new() where TR : class
    {
        protected RestRequest Request = new RestRequest();
        private readonly ISoundCloudApiInternal _soundCloudApi;

        protected ResourceBase(ISoundCloudApiInternal soundCloudApi)
        {
            Request.RequestFormat = DataFormat.Json;
            //Request.JsonSerializer = new SoundCloudSerializer();
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

        public T Put()
        {
            Request.Method = Method.PUT;
            return _soundCloudApi.Execute(this);
        }

        public void PutAsync(Action<T> callback)
        {
            Request.Method = Method.PUT;
            _soundCloudApi.ExecuteAsync(this, callback);
        }

        public T Put(T model)
        {
            Request.Method = Method.PUT;
            Request.AddObject(model);
            return _soundCloudApi.Execute(this);
        }

        public void PutAsync(T model, Action<T> callback)
        {
            Request.Method = Method.PUT;
            Request.AddObject(model);
            _soundCloudApi.ExecuteAsync(this, callback);
        }

        public void Delete()
        {
            Request.Method = Method.DELETE;
            _soundCloudApi.Execute(this);
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

        public TR Filter(Filter filter)
        {
            Request.AddParameter(QueryParameter.Filter, filter.ToString(), ParameterType.GetOrPost);
            return this as TR;
        }

        public TR License(LicenseFilter license)
        {
            Request.AddParameter(QueryParameter.License, (string)license, ParameterType.GetOrPost);
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

        public TR DurationFrom(int milliseconds)
        {
            Request.AddParameter(QueryParameter.DurationFrom, milliseconds, ParameterType.GetOrPost);
            return this as TR;
        }

        public TR DurationTo(int milliseconds)
        {
            Request.AddParameter(QueryParameter.DurationTo, milliseconds, ParameterType.GetOrPost);
            return this as TR;
        }

        public TR CreatedFrom(DateTime date)
        {
            Request.AddParameter(QueryParameter.CreatedFrom, date.ToString("u"), ParameterType.GetOrPost);
            return this as TR;
        }

        public TR CreatedTo(DateTime date)
        {
            Request.AddParameter(QueryParameter.CreatedTo, date.ToString("u"), ParameterType.GetOrPost);
            return this as TR;
        }

        public TR Ids(IEnumerable<int> list)
        {
            Request.AddParameter(QueryParameter.Ids, string.Join(",", list), ParameterType.GetOrPost);
            return this as TR;
        }

        public TR Genres(IEnumerable<string> list)
        {
            Request.AddParameter(QueryParameter.Genres, string.Join(",", list), ParameterType.GetOrPost);
            return this as TR;
        }

        public TR Types(IEnumerable<TypeFilter> list)
        {
            Request.AddParameter(QueryParameter.Types, string.Join(",", list.Select(typeFilter => (string)typeFilter).ToList()), ParameterType.GetOrPost);
            return this as TR;
        }
    }
}
