using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using SoundCloud.Api.Net.Authentication;
using SoundCloud.Api.Net.Configuration;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources;
using SoundCloud.Api.Net.Resources.Me;
using SoundCloud.Api.Net.Resources.User;
using User = SoundCloud.Api.Net.Models.User;

namespace SoundCloud.Api.Net
{
    public sealed class SoundCloudApiAuthenticated : SoundCloudApiUnAuthenticated, ISoundCloudApiAuthenticated
    {
        private readonly string _clientId;
        private readonly string _secretKey;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _authorizationCode;
        private readonly IPasswordCredentialsState _passwordCredentialsState;
        private static readonly RestClient Client = new RestClient(Settings.BaseUrlSsl);
        
        private bool _usePassword, _useAuthorizationCode;
        private PasswordCredentials _currentOAuthToken;

        internal SoundCloudApiAuthenticated(
            string clientId, 
            string secretKey,
            string userName, 
            string password,
            IPasswordCredentialsState passwordCredentialsState) 
            : this(clientId, secretKey, passwordCredentialsState)
        {
            _userName = userName;
            _password = password;
            _usePassword = true;
        }

        internal SoundCloudApiAuthenticated(
            string clientId, 
            string secretKey,
            string authorizationCode,
            IPasswordCredentialsState passwordCredentialsState)
            : this(clientId, secretKey, passwordCredentialsState)
        {
            _authorizationCode = authorizationCode;
            _useAuthorizationCode = true;
        }

        internal SoundCloudApiAuthenticated(
            string clientId, 
            string secretKey,
            IPasswordCredentialsState passwordCredentialsState)
            : base(clientId, Client)
        {
            _clientId = clientId;
            _secretKey = secretKey;
            _passwordCredentialsState = passwordCredentialsState;
        }

        public override void ExecuteAsync<T>(IResource<T> resource, Action<T> callback)
        {
            GetOAuth2Token();
            resource.SetRequest(AddRestClientToken(resource));
            base.ExecuteAsync(resource, callback);
        }

        public override List<T> Execute<T>(IEnumerable<IResource<T>> resources)
        {
            GetOAuth2Token();

            var resourceBases = resources as IList<IResource<T>> ?? resources.ToList();

            foreach (var resource in resourceBases)
            {
                resource.SetRequest(AddRestClientToken(resource));
            }

            return base.Execute(resourceBases);
        }

        public override void ExecuteAsync<T>(IEnumerable<IResource<T>> resources, Action<List<T>> callback)
        {
            GetOAuth2Token();

            var resourceBases = resources as IList<IResource<T>> ?? resources.ToList();

            foreach (var resource in resourceBases)
            {
                resource.SetRequest(AddRestClientToken(resource));
            }

            base.ExecuteAsync(resourceBases, callback);
        }

        public override T Execute<T>(IResource<T> resource)
        {
            GetOAuth2Token();
            resource.SetRequest(AddRestClientToken(resource));
            return base.Execute(resource);
        }

        private void GetOAuth2Token()
        {
            if (!IsTokenRequired())
            {
                return;
            }

            var oauth2Token = GetOauth2Model();

            var request = new OAuth2Token(oauth2Token, this).GetRequest();

            var response = Client.Execute<PasswordCredentials>(request);

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

            return _currentOAuthToken.HasExpired();
        }

        private OAuth2 GetOauth2Model()
        {
            var oauth2Token = new OAuth2 { ClientId = _clientId, ClientSecret = _secretKey };

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
                oauth2Token.RefreshToken = _currentOAuthToken.RefreshToken;
            }

            return oauth2Token;
        }

        private RestRequest AddRestClientToken<T>(IResource<T> resource) where T : new()
        {
            var request = resource.GetRequest();
            var passwordCredentials = _passwordCredentialsState.Load();
            request.AddParameter(QueryParameter.OAuthToken, passwordCredentials.AccessToken, ParameterType.GetOrPost);
            return request;
        }

        public IUser User()
        {
            return new Resources.User.User(this);
        }

        public IMe Me()
        {
            return new Me(this);
        }
    }
}