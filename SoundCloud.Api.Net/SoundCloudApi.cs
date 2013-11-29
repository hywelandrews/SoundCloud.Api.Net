using SoundCloud.Api.Net.Authentication;

namespace SoundCloud.Api.Net
{
    public static class SoundCloudApi
    {
        public static ISoundCloudApiUnAuthenticated CreateClient(string clientId)
        {
            return new SoundCloudApiUnAuthenticated(clientId);
        }

        public static ISoundCloudApiAuthenticated CreateClient(string clientId, 
                                                      string secretKey,
                                                      string userName, 
                                                      string password,
                                                      IPasswordCredentialsState passwordCredentialsState)
        {
            return new SoundCloudApiAuthenticated(clientId, secretKey, userName, password, passwordCredentialsState);
        }

        public static ISoundCloudApiAuthenticated CreateClient(string clientId, 
                                                      string secretKey,
                                                      IPasswordCredentialsState passwordCredentialsState)
        {
            return new SoundCloudApiAuthenticated(clientId, secretKey, passwordCredentialsState);
        }

        public static ISoundCloudApiAuthenticated CreateClient(string clientId, 
                                                      string secretKey, 
                                                      string authorizationCode,
                                                      IPasswordCredentialsState passwordCredentialsState)
        {
            return new SoundCloudApiAuthenticated(clientId, secretKey, authorizationCode, passwordCredentialsState);
        }
    }
}
