using System;
using RestSharp;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources
{
    internal class OAuth2Token : ResourceBase<Models.OAuth2, OAuth2Token>
    {
        internal OAuth2Token(OAuth2 oAuth2, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request.Resource = "/oauth2/token";
            Request.Method = Method.POST;
            Request.AddParameter(FormParameter.ClientId, oAuth2.ClientId);
            Request.AddParameter(FormParameter.ClientSecret, oAuth2.ClientSecret);
            Request.AddParameter(FormParameter.GrantType, oAuth2.GrantType.ToString());

            switch (oAuth2.GrantType)
            {
                case GrantType.password:
                    AddPasswordParameters(oAuth2);
                    break;
                case GrantType.authorization_code:
                    AddAuthorizationCodeParameters(oAuth2);
                    break;
                case GrantType.refresh_token:
                    AddRefreshTokenParameters(oAuth2);
                    break;
            }
        }

        private void AddRefreshTokenParameters(OAuth2 oAuth2)
        {
            if (string.IsNullOrEmpty(oAuth2.RefreshToken))
            {
                throw new Exception("GranType of Refresh token requires a refresh token");
            }
            Request.AddParameter(FormParameter.Code, oAuth2.RefreshToken);
        }

        private void AddAuthorizationCodeParameters(OAuth2 oAuth2)
        {
            if ((string.IsNullOrEmpty(oAuth2.Code) || string.IsNullOrEmpty(oAuth2.RedirectUri)))
            {
                throw new Exception("GranType of Authorization code requires code and redirect uri");
            }

            Request.AddParameter(FormParameter.Code, oAuth2.Code);
            Request.AddParameter(FormParameter.RedirectUri, oAuth2.RedirectUri);
        }

        private void AddPasswordParameters(OAuth2 oAuth2)
        {
            if ((string.IsNullOrEmpty(oAuth2.UserName) || string.IsNullOrEmpty(oAuth2.Password)))
            {
                throw new Exception("GranType of Password requires username and password");
            }

            Request.AddParameter(FormParameter.Username, oAuth2.UserName);
            Request.AddParameter(FormParameter.Password, oAuth2.Password);
        }
    }
}
