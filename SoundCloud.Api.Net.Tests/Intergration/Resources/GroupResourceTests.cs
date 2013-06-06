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
            var group = SoundCloudApi.Group(1).Get();
            Assert.AreEqual(1, group.Id);
        }

        [Test]
        public void TestGetGroupWithOAuthRequest()
        {
            var group = SoundCloudApiAuthenticate.Group(1).Get();
            Assert.AreEqual(1, group.Id);
        }

        [Test]
        public void TestGetGroupAsyncWithOAuth()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiAuthenticate.Group(1).GetAsync(GroupBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.IsNotEmpty(_asyncGroupResult.Name);
        }

        [Test]
        public void TestGetGroupMultipleRequests()
        {
            var resourceList = new List<IGroup>
                {
                    SoundCloudApi.Group(1),
                    SoundCloudApi.Group(1),
                    SoundCloudApi.Group(1),
                };

            var groups = SoundCloudApi.Execute(resourceList);
            Assert.AreEqual(3, groups.Count);
        }

        private void GroupBuilder(Group result)
        {
            _asyncGroupResult = result;
            Completion.Set();
        }
    }
}
