using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Groups;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class GroupsResourceTests : ResourceTestsBase
    {
        private List<Group> _asyncGroupsResult;

        [Test]
        public void TestGetGroupsRequest()
        {
            var groups = SoundCloudApiUnAuthenticated.Groups().Get();
            Assert.Greater(groups.Count, 0);
        }

        [Test]
        public void TestGetGroupsWithSearchRequest()
        {
            var groups = SoundCloudApiUnAuthenticated.Groups().Search("Owl").Get();
            Assert.Greater(groups.Count, 0);
        }

        [Test]
        public void TestGetGroupsAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Groups().GetAsync(GroupsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncGroupsResult.Count, 0);
        }

        [Test]
        public void TestGetGroupsWithSearchAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Groups().Search("Owl").GetAsync(GroupsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncGroupsResult.Count, 0);
        }

        [Test]
        public void TestGetGroupsMultipleRequest()
        {
            var requests = new List<IGroups>
                {
                    SoundCloudApiUnAuthenticated.Groups(),
                    SoundCloudApiUnAuthenticated.Groups(),
                    SoundCloudApiUnAuthenticated.Groups(),
                };
            var users = SoundCloudApiUnAuthenticated.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetGroupsWithOAuthMultipleRequest()
        {
            var requests = new List<IGroups>
                {
                    SoundCloudApiAuthenticated.Groups(),
                    SoundCloudApiAuthenticated.Groups(),
                    SoundCloudApiAuthenticated.Groups(),
                };
            var users = SoundCloudApiAuthenticated.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetGroupsAsyncMultipleRequest()
        {
            Completion = new ManualResetEvent(false);
            var requests = new List<IGroups>
                {
                    SoundCloudApiAuthenticated.Groups(),
                    SoundCloudApiAuthenticated.Groups(),
                    SoundCloudApiAuthenticated.Groups(),
                };
            SoundCloudApiAuthenticated.ExecuteAsync(requests, GroupsListBuilder);
            Assert.Greater(_asyncGroupsResult.Count, 0);
        }

        private void GroupsListBuilder(List<Group> result)
        {
            _asyncGroupsResult = result;
            Completion.Set();
        }

        private void GroupsListBuilder(List<List<Group>> result)
        {
            _asyncGroupsResult = new List<Group>();
            foreach (var userResult in result)
            {
                _asyncGroupsResult.InsertRange(0, userResult);
            }
            Completion.Set();
        }
    }
}
