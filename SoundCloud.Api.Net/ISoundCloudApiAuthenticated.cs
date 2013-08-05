using SoundCloud.Api.Net.Resources.Me;
using SoundCloud.Api.Net.Resources.User;

namespace SoundCloud.Api.Net
{
    public interface ISoundCloudApiAuthenticated : ISoundCloudApiUnAuthenticated
    {
        IUser User();
        IMe Me();
    }
}
