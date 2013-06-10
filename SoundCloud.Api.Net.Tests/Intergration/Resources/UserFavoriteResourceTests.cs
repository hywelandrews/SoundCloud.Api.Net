using NUnit.Framework;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class UserFavoriteResourceTests : ResourceTestsBase
    {
        [Test]
        public void TestPutUserFavoriteRequest()
        {
            var track = SoundCloudApiAuthenticate.User().Favorite(11195729).Put();
            Assert.IsNotNullOrEmpty(track.Title);
        }

        [Test]
        public void TestDeleteUserFavoriteRequest()
        {
            SoundCloudApiAuthenticate.User().Favorite(11195729).Put();
            SoundCloudApiAuthenticate.User().Favorite(11195729).Delete();
        }

        [TestFixtureTearDown]
        public void UserFavoriteResourceTestsTearDown()
        {
            SoundCloudApiAuthenticate.User().Favorite(11195729).Delete();
        }
    }
}
