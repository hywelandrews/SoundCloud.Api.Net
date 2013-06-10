using NUnit.Framework;
using SoundCloud.Api.Net.Models;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class UserWebProfileResourceTests : ResourceTestsBase
    {
        [Test]
        public void TestPutUserWebProfileRequest()
        {
            var webProfile = new WebProfile
                {
                    Id = 4783141,
                    Service = "personal",
                    Title = "A website",
                    Url = "http://grasshopperliesheavy.co.uk"
                };
            SoundCloudApiAuthenticate.User().WebProfile(4783141).Put(webProfile);
        }

        [Test]
        public void TestDeleteUserWebProfileRequest()
        {
            SoundCloudApiAuthenticate.User().WebProfile(4783141).Delete();
        }
    }
}
