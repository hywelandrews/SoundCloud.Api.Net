using System;
using NUnit.Framework;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class UserFollowingResourceTests : ResourceTestsBase
    {
        [Test]
        public void TestPutUserFollowingRequest()
        {
            var user = SoundCloudApiAuthenticated.User().Following(17567595).Put();
            Assert.IsNotNullOrEmpty(user.Username);
        }

        [Test]
        public void TestDeleteUserFollowingRequest()
        {
            SoundCloudApiAuthenticated.User().Following(17567595).Delete();
        }

        [TestFixtureTearDown]
        public void UserFollowingResourceTestsTearDown()
        {
            SoundCloudApiAuthenticated.User().Following(17567595).Delete();
        }
    }
}
