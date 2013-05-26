using SoundCloud.Api.Net.Authentication;

namespace SoundCloud.Api.Net
{
    public static class SoundCloudApiFactory
    {
        public static ISoundCloudApi GetSoundCloudApi(string clientId, string secretKey)
        {
            return new SoundCloudApi(clientId, secretKey);
        }

        public static ISoundCloudApi GetSoundCloudApi(string clientId, string secretKey,
            string userName, string password,
            IPasswordCredentialsState passwordCredentialsState)
        {
            return new SoundCloudApiAuthenticated(clientId, secretKey, userName, password, passwordCredentialsState);
        }

        public static ISoundCloudApi GetSoundCloudApi(string clientId, string secretKey,
        IPasswordCredentialsState passwordCredentialsState)
        {
            return new SoundCloudApiAuthenticated(clientId, secretKey, passwordCredentialsState);
        }

        public static ISoundCloudApi GetSoundCloudApi(string clientId, string secretKey, string authorizationCode,
            IPasswordCredentialsState passwordCredentialsState)
        {
            return new SoundCloudApiAuthenticated(clientId, secretKey, authorizationCode, passwordCredentialsState);
        }
    }
}
