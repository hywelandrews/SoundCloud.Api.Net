using SoundCloud.Api.Net.Authentication;

namespace SoundCloud.Api.Net.Authentication
{
    public interface IPasswordCredentialsState
    {
         PasswordCredentials Load();
         bool Save(PasswordCredentials passwordCredentials);
    }
}
