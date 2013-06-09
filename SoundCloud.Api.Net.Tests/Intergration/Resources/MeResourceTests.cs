﻿using NUnit.Framework;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class MeResourceTests : ResourceTestsBase
    {
        [Test]
        public void TestGetMeRequest()
        {
            var user = SoundCloudApiAuthenticate.Me().Get();
            Assert.IsNotNullOrEmpty(user.Username);
        }
    }
}