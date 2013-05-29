using NUnit.Framework;

namespace SoundCloud.Api.Net.Tests.Resources
{
    public class UsersResourceTests: ResourceTestsBase
    {
        [Test]
        public void TestGetUsersRequest()
        {
            var user = SoundCloudApi.Users().Get();
            Assert.Greater(user.Count, 0);
        }

        [Test]
        public void TestGetUsersWithSearchRequest()
        {
            var user = SoundCloudApi.Users().Search("Owl").Get();
            Assert.Greater(user.Count, 0);
        }
    }
}
