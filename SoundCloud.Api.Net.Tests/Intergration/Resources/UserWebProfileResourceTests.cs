using NUnit.Framework;
using SoundCloud.Api.Net.Models;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class UserWebProfileResourceTests : ResourceTestsBase
    {
        [Test]
        public void TestGetUserWebProfileRequest()
        {
            var i = SoundCloudApiAuthenticated.User().WebProfiles().Get();

        }

        [Test]
        public void TestPutUserWebProfileRequest()
        {
            var webProfile = new WebProfile
                {
                    Id = 26382185,
                    Service = "other",
                    Title = "A website",
                    Url = "http://owlmusic.bandcamp.com/"
                };
            SoundCloudApiAuthenticated.User().WebProfile(26382185).Put(webProfile);
        }

        [Ignore]
        [Test]
        public void TestDeleteUserWebProfileRequest()
        {
            SoundCloudApiAuthenticated.User().WebProfile(4783141).Delete();
        }
    }
}
