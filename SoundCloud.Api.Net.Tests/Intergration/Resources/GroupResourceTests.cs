using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Group;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class GroupResourceTests : ResourceTestsBase
    {
        private Group _asyncGroupResult;

        [Test]
        public void TestGetGroupRequest()
        {
            var group = SoundCloudApiUnAuthenticated.Group(1).Get();
            Assert.AreEqual(1, group.Id);
        }

        [Test]
        public void TestGetGroupWithOAuthRequest()
        {
            var group = SoundCloudApiAuthenticated.Group(1).Get();
            Assert.AreEqual(1, group.Id);
        }

        [Test]
        public void TestGetGroupAsyncWithOAuth()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiAuthenticated.Group(1).GetAsync(GroupBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.IsNotEmpty(_asyncGroupResult.Name);
        }

        [Test]
        public void TestGetGroupMultipleRequests()
        {
            var resourceList = new List<IGroup>
                {
                    SoundCloudApiUnAuthenticated.Group(1),
                    SoundCloudApiUnAuthenticated.Group(1),
                    SoundCloudApiUnAuthenticated.Group(1),
                };

            var groups = SoundCloudApiUnAuthenticated.Execute(resourceList);
            Assert.AreEqual(3, groups.Count);
        }

        private void GroupBuilder(Group result)
        {
            _asyncGroupResult = result;
            Completion.Set();
        }
    }
}
