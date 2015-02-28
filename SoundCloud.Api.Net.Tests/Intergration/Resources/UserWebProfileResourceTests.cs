using NUnit.Framework;
using SoundCloud.Api.Net.Models;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class UserWebProfileResourceTests : ResourceTestsBase
    {
        private WebProfile _webProfile;

        [TestFixtureSetUp]
        public void Setup()
        {
            _webProfile = new WebProfile
            {
                Service = "twitter",
                Title = "Owl",
                Url = "http://twitter.com/owlandrews"
            };
        }
        [Test]
        public void TestGetUserWebProfileRequest()
        {
            var webprofile = SoundCloudApiAuthenticated.User().WebProfiles().Get();
            Assert.IsNotNull(webprofile);
        }

        [Test]
        public void TestCreateUserWebProfileRequest()
        {
            var webProfileWithId = SoundCloudApiAuthenticated.User(509497).WebProfile().Post(_webProfile);
            var newWebProfile = SoundCloudApiAuthenticated.User(509497).WebProfile(webProfileWithId.Id).Get();
            Assert.AreEqual(webProfileWithId.Id, newWebProfile.Id);
            SoundCloudApiAuthenticated.User().WebProfile(webProfileWithId.Id).Delete();
        }

        [Test]
        public void TestDeleteUserWebProfileRequest()
        {
            var webProfileWithId = SoundCloudApiAuthenticated.User(509497).WebProfile().Post(_webProfile);
            SoundCloudApiAuthenticated.User().WebProfile(webProfileWithId.Id).Delete();
        }

        [Test]
        public void TestPutUserWebProfileRequest()
        {
            var webProfileWithId = SoundCloudApiAuthenticated.User(509497).WebProfile().Post(_webProfile);
            webProfileWithId.Title = "Owl 2";
            SoundCloudApiAuthenticated.User().WebProfile(webProfileWithId.Id).Put(webProfileWithId);
            var scVersion = SoundCloudApiAuthenticated.User().WebProfile(webProfileWithId.Id).Get();
            Assert.AreEqual(webProfileWithId.Title, scVersion.Title);
            SoundCloudApiAuthenticated.User().WebProfile(webProfileWithId.Id).Delete();
        }
    }
}
