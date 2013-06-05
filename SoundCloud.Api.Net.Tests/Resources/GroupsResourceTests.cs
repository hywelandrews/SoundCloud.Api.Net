using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Groups;

namespace SoundCloud.Api.Net.Tests.Resources
{
    [TestFixture]
    public class GroupsResourceTests : ResourceTestsBase
    {
        private List<Group> _asyncGroupsResult;

        [Test]
        public void TestGetPlaylistsRequest()
        {
            var playlists = SoundCloudApi.Groups().Get();
            Assert.Greater(playlists.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsWithSearchRequest()
        {
            var playlists = SoundCloudApi.Groups().Search("Owl").Get();
            Assert.Greater(playlists.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApi.Groups().GetAsync(GroupsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncGroupsResult.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsWithSearchAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApi.Groups().Search("Owl").GetAsync(GroupsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncGroupsResult.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsMultipleRequest()
        {
            var requests = new List<IGroups>
                {
                    SoundCloudApi.Groups(),
                    SoundCloudApi.Groups(),
                    SoundCloudApi.Groups(),
                };
            var users = SoundCloudApi.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsWithOAuthMultipleRequest()
        {
            var requests = new List<IGroups>
                {
                    SoundCloudApiAuthenticate.Groups(),
                    SoundCloudApiAuthenticate.Groups(),
                    SoundCloudApiAuthenticate.Groups(),
                };
            var users = SoundCloudApiAuthenticate.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsAsyncMultipleRequest()
        {
            Completion = new ManualResetEvent(false);
            var requests = new List<IGroups>
                {
                    SoundCloudApi.Groups(),
                    SoundCloudApi.Groups(),
                    SoundCloudApi.Groups(),
                };
            SoundCloudApiAuthenticate.ExecuteAsync(requests, GroupsListBuilder);
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
