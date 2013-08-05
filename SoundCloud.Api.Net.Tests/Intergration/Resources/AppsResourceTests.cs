using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Apps;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class AppsResourceTests : ResourceTestsBase
    {
        private List<App> _asyncAppsResult;

        [Test]
        public void TestGetAppsRequest()
        {
            var playlists = SoundCloudApiUnAuthenticated.Apps().Get();
            Assert.Greater(playlists.Count, 0);
        }

        [Test]
        public void TestGetAppsAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Apps().GetAsync(AppsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncAppsResult.Count, 0);
        }

        [Test]
        public void TestGetAppsMultipleRequest()
        {
            var requests = new List<IApps>
                {
                    SoundCloudApiUnAuthenticated.Apps(),
                    SoundCloudApiUnAuthenticated.Apps(),
                    SoundCloudApiUnAuthenticated.Apps(),
                };
            var users = SoundCloudApiUnAuthenticated.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetAppsWithOAuthMultipleRequest()
        {
            var requests = new List<IApps>
                {
                    SoundCloudApiAuthenticated.Apps(),
                    SoundCloudApiAuthenticated.Apps(),
                    SoundCloudApiAuthenticated.Apps(),
                };
            var users = SoundCloudApiAuthenticated.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetAppsAsyncMultipleRequest()
        {
            Completion = new ManualResetEvent(false);
            var requests = new List<IApps>
                {
                    SoundCloudApiAuthenticated.Apps(),
                    SoundCloudApiAuthenticated.Apps(),
                    SoundCloudApiAuthenticated.Apps(),
                };
            SoundCloudApiAuthenticated.ExecuteAsync(requests, AppsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncAppsResult.Count, 0);
        }

        private void AppsListBuilder(List<App> result)
        {
            _asyncAppsResult = result;
            Completion.Set();
        }

        private void AppsListBuilder(IEnumerable<List<App>> result)
        {
            _asyncAppsResult = new List<App>();
            foreach (var userResult in result)
            {
                _asyncAppsResult.InsertRange(0, userResult);
            }
            Completion.Set();
        }
    }
}
