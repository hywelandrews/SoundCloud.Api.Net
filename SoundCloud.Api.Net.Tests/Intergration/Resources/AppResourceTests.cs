using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.App;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class AppResourceTests : ResourceTestsBase
    {
        private App _asyncAppResult;

        [Test]
        public void TestGetAppRequest()
        {
            var app = SoundCloudApiUnAuthenticated.App(69118).Get();
            Assert.AreEqual(69118, app.Id);
        }

        [Test]
        public void TestGetAppWithOAuthRequest()
        {
            var app = SoundCloudApiAuthenticated.App(69118).Get();
            Assert.AreEqual(69118, app.Id);
        }

        [Test]
        public void TestGetAppAsyncWithOAuth()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiAuthenticated.App(69118).GetAsync(CommentBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.IsNotEmpty(_asyncAppResult.Name);
        }

        [Test]
        public void TestGetAppMultipleRequests()
        {
            var resourceList = new List<IApp>
                {
                    SoundCloudApiUnAuthenticated.App(69118),
                    SoundCloudApiUnAuthenticated.App(69118),
                    SoundCloudApiUnAuthenticated.App(69118),
                };

            var app = SoundCloudApiUnAuthenticated.Execute(resourceList);
            Assert.AreEqual(3, app.Count);
        }

        private void CommentBuilder(App result)
        {
            _asyncAppResult = result;
            Completion.Set();
        }
    }
}
