using SoundCloud.Api.Net.Authentication;

namespace SoundCloud.Api.Net.Tests.Resources
{
    public class PasswordCredentialsState : IPasswordCredentialsState
    {
        private PasswordCredentials _passwordCredentials;

        public PasswordCredentials Load()
        {
            return _passwordCredentials;
        }

        public bool Save(PasswordCredentials passwordCredentials)
        {
            _passwordCredentials = passwordCredentials;
            return true;
        }
    }
}
