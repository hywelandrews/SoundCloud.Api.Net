using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using SoundCloud.Api.Net.Configuration;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources;

namespace SoundCloud.Api.Net
{
    public class SoundCloudApi : ISoundCloudApi
    {
        private readonly string _clientId;
        private readonly string _secretKey;
        private readonly RestClient _client;

        internal SoundCloudApi(string clientId, string secretKey)
        {
            _clientId = clientId;
            _secretKey = secretKey;
            _client = new RestClient { BaseUrl = Settings.BaseUrl };
        }

        internal SoundCloudApi(string clientId, string secretKey, RestClient client)
        {
            _clientId = clientId;
            _secretKey = secretKey;
            _client = client;
        }

        public void ExecuteAsync<T>(ResourceBase<T> resource, Action<T> callback) where T : new()
        {
            var request = CreateRestClientRequest(resource);
            _client.ExecuteAsync<T>(request, (response) => callback(response.Data));
        }

        public List<T> Execute<T>(IEnumerable<ResourceBase<T>> resources) where T : new()
        {
            var compositeBuilderResult = ExecuteMultipleResources(resources);

            return compositeBuilderResult.Result;
        }
        
        public void ExecuteAsync<T>(IEnumerable<ResourceBase<T>> resources, Action<List<T>> callback) where T : new()
        {
            var compositeBuilderResult = ExecuteMultipleResources(resources);
            callback(compositeBuilderResult.Result);
        }

        public T Execute<T>(ResourceBase<T> resource) where T : new()
        {
            var request = CreateRestClientRequest(resource);

            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return response.Data;
        }

        private Task<List<T>> ExecuteMultipleResources<T>(IEnumerable<ResourceBase<T>> resources) where T : new()
        {
            var requests = new List<IRestRequest>((from resource in resources select CreateRestClientRequest(resource)).ToList());

            var tasks = new List<Task<T>>();

            foreach (var request in requests)
            {
                IRestRequest currentRequest = request;
                tasks.Add(Task.Factory.StartNew(() => _client.Execute<T>(currentRequest).Data, TaskCreationOptions.LongRunning));
            }

            var compositeBuilderResult = Task.Factory.ContinueWhenAll<T, List<T>>(tasks.ToArray(), compositeBuilder);
            return compositeBuilderResult;
        }



        private List<T> compositeBuilder<T>(IEnumerable<Task<T>> taskResults)
        {
            return taskResults.Select(t => t.Result).ToList();
        }

        private RestRequest CreateRestClientRequest<T>(ResourceBase<T> resource) where T : new()
        {
            var request = resource.GetRequest();

            // used on every request
            request.AddParameter(QueryParameter.ClientId, _clientId, ParameterType.GetOrPost);
            request.AddParameter(QueryParameter.Consumerkey, _secretKey, ParameterType.GetOrPost);
            return request;
        }
    }
}
