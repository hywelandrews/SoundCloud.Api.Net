using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using SoundCloud.Api.Net.Authentication;
using SoundCloud.Api.Net.Configuration;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources;

namespace SoundCloud.Api.Net
{
    public class SoundCloudApiAuthenticated : ISoundCloudApi
    {
        private readonly SoundCloudApi _soundCloudApi;
        private readonly string _clientId;
        private readonly string _secretKey;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _authorizationCode;
        private readonly IPasswordCredentialsState _passwordCredentialsState;
        private readonly RestClient _client;
        
        private bool _usePassword, _useAuthorizationCode;
        private PasswordCredentials _currentOAuthToken;

        internal SoundCloudApiAuthenticated(
            string clientId, string secretKey,
            string userName, string password,
            IPasswordCredentialsState passwordCredentialsState) 
            : this(clientId, secretKey, passwordCredentialsState)
        {
            _userName = userName;
            _password = password;
            _usePassword = true;
        }

        internal SoundCloudApiAuthenticated(
            string clientId, string secretKey,
            string authorizationCode,
            IPasswordCredentialsState passwordCredentialsState)
            : this(clientId, secretKey, passwordCredentialsState)
        {
            _authorizationCode = authorizationCode;
            _useAuthorizationCode = true;
        }

        internal SoundCloudApiAuthenticated(
            string clientId, string secretKey,
            IPasswordCredentialsState passwordCredentialsState)
        {
            _clientId = clientId;
            _secretKey = secretKey;
            _passwordCredentialsState = passwordCredentialsState;
            _client = new RestClient(Settings.BaseUrlSsl);
            _soundCloudApi = new SoundCloudApi(clientId, secretKey, _client);
        }

        public void ExecuteAsync<T>(ResourceBase<T> resource, Action<T> callback) where T : new()
        {
            GetOAuth2Token();
            resource.SetRequest(AddRestClientToken(resource));
            _soundCloudApi.ExecuteAsync(resource, callback);
        }

        public List<T> Execute<T>(IEnumerable<ResourceBase<T>> resources) where T : new()
        {
            GetOAuth2Token();

            var resourceBases = resources as IList<ResourceBase<T>> ?? resources.ToList();
            foreach (var resource in resourceBases)
                resource.SetRequest(AddRestClientToken(resource));

            return _soundCloudApi.Execute(resourceBases);
        }

        public void ExecuteAsync<T>(IEnumerable<ResourceBase<T>> resources, Action<List<T>> callback) where T : new()
        {
            GetOAuth2Token();

            var resourceBases = resources as IList<ResourceBase<T>> ?? resources.ToList();
            foreach (var resource in resourceBases)
                resource.SetRequest(AddRestClientToken(resource));

            _soundCloudApi.ExecuteAsync(resourceBases, callback);
        }

        public T Execute<T>(ResourceBase<T> resource) where T : new()
        {
            GetOAuth2Token();
            resource.SetRequest(AddRestClientToken(resource));
            return _soundCloudApi.Execute(resource);
        }

        private void GetOAuth2Token()
        {
            if (!IsTokenRequired()) return;

            var oauth2Token = GetOauth2Model();

            var request = new OAuth2Token(oauth2Token).GetRequest();

            var client = new RestClient {BaseUrl = Settings.BaseUrlSsl};

            var response = client.Execute<PasswordCredentials>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            _passwordCredentialsState.Save(response.Data);
        }

        private bool IsTokenRequired()
        {
            if (_usePassword || _useAuthorizationCode)
            {
                return true;
            }

            _currentOAuthToken = _passwordCredentialsState.Load();

            return !_currentOAuthToken.HasExpired();
        }

        private OAuth2 GetOauth2Model()
        {
            var oauth2Token = new OAuth2 {ClientId = _clientId, ClientSecret = _secretKey};

            if (_usePassword)
            {
                oauth2Token.GrantType = GrantType.password;
                oauth2Token.UserName = _userName;
                oauth2Token.Password = _password;
                _usePassword = false;
            }
            else if (_useAuthorizationCode)
            {
                oauth2Token.GrantType = GrantType.authorization_code;
                oauth2Token.Code = _authorizationCode;
                _useAuthorizationCode = false;
            }
            else
            {
                oauth2Token.GrantType = GrantType.refresh_token;
                oauth2Token.RefreshToken = _currentOAuthToken.refresh_token;
            }

            return oauth2Token;
        }

        private RestRequest AddRestClientToken<T>(ResourceBase<T> resource) where T : new()
        {
            var request = resource.GetRequest();
            var passwordCredentials = _passwordCredentialsState.Load();
            request.AddParameter(QueryParameter.OAuthToken, passwordCredentials.access_token, ParameterType.GetOrPost);
            return request;
        }
    }
}