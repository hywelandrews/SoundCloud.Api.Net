using NUnit.Framework;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class UserFavoriteResourceTests : ResourceTestsBase
    {
        [Test]
        public void TestPutUserFavoriteRequest()
        {
            SoundCloudApiAuthenticated.User().Favorite(11195729).Put();
        }

        [Test]
        public void TestDeleteUserFavoriteRequest()
        {
            SoundCloudApiAuthenticated.User().Favorite(11195729).Put();
            SoundCloudApiAuthenticated.User().Favorite(11195729).Delete();
        }

        [TestFixtureTearDown]
        public void UserFavoriteResourceTestsTearDown()
        {
            SoundCloudApiAuthenticated.User().Favorite(11195729).Delete();
        }
    }
}
