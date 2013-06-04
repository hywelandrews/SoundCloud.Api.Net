using System;

namespace SoundCloud.Api.Net.Authentication
{
    public class PasswordCredentials
    {
        public string AccessToken { get; private set; }

        public int ExpiresIn { get; set; }

        public string Scope { get; set; }

        public string RefreshToken { get; private set; }

        private DateTime _creaedAt;

        public bool HasExpired()
        {
            var tokenExpiresAt = _creaedAt.AddSeconds(ExpiresIn);
            return tokenExpiresAt <= DateTime.Now;
        }

        public PasswordCredentials()
        {
            _creaedAt = DateTime.Now;
        }

        public PasswordCredentials(string accessToken, string refreshToken, int expiresIn, DateTime createdAt)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
            
            _creaedAt = createdAt;
        }
    }
}
