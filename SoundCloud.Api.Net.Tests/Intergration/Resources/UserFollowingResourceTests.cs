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
            var user = SoundCloudApiAuthenticate.User().Following(17567594).Put();
            Assert.IsNotNullOrEmpty(user.Username);
        }

        [Test]
        public void TestDeleteUserFollowingRequest()
        {
            SoundCloudApiAuthenticate.User().Following(17567594).Delete();
        }
    }
}
