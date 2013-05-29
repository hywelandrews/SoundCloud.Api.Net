using System;

namespace SoundCloud.Api.Net.Authentication
{
    public class PasswordCredentials
    {
        public string access_token { get; private set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public string refresh_token { get; private set; }

        private DateTime _creaedAt;

        public PasswordCredentials()
        {
            _creaedAt = DateTime.Now;
        }

        public PasswordCredentials(string access_token, string refresh_token, int expires_in, DateTime createdAt)
        {
            this.access_token = access_token;
            this.refresh_token = refresh_token;
            this.expires_in = expires_in;
            
            _creaedAt = createdAt;
        }

        public bool HasExpired()
        {
            var tokenExpiresAt = _creaedAt.AddSeconds(expires_in);
            return (tokenExpiresAt <= DateTime.Now);
        }
    }
}
