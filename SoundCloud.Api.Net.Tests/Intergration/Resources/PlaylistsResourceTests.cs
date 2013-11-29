using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Playlists;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class PlaylistsResourceTests : ResourceTestsBase
    {
        private List<Playlist> _asyncPlaylistsResult;

        [Test]
        public void TestGetPlaylistsRequest()
        {
            var playlists = SoundCloudApiUnAuthenticated.Playlists().Get();
            Assert.Greater(playlists.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsWithSearchRequest()
        {
            var playlists = SoundCloudApiUnAuthenticated.Playlists().Search("Owl").Get();
            Assert.Greater(playlists.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Playlists().GetAsync(PlaylistsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncPlaylistsResult.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsWithSearchAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Playlists().Search("Owl").GetAsync(PlaylistsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncPlaylistsResult.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsMultipleRequest()
        {
            var requests = new List<IPlaylists>
                {
                    SoundCloudApiUnAuthenticated.Playlists(),
                    SoundCloudApiUnAuthenticated.Playlists(),
                    SoundCloudApiUnAuthenticated.Playlists(),
                };
            var playlists = SoundCloudApiUnAuthenticated.Execute(requests);
            Assert.Greater(playlists.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsWithOAuthMultipleRequest()
        {
            var requests = new List<IPlaylists>
                {
                    SoundCloudApiAuthenticated.Playlists(),
                    SoundCloudApiAuthenticated.Playlists(),
                    SoundCloudApiAuthenticated.Playlists(),
                };
            var playlists = SoundCloudApiAuthenticated.Execute(requests);
            Assert.Greater(playlists.Count, 0);
        }

        [Test]
        public void TestGetPlaylistsAsyncMultipleRequest()
        {
            Completion = new ManualResetEvent(false);
            var requests = new List<IPlaylists>
                {
                    SoundCloudApiAuthenticated.Playlists(),
                    SoundCloudApiAuthenticated.Playlists(),
                    SoundCloudApiAuthenticated.Playlists(),
                };
            SoundCloudApiAuthenticated.ExecuteAsync(requests, PlaylistsListBuilder);
            Assert.Greater(_asyncPlaylistsResult.Count, 0);
        }

        private void PlaylistsListBuilder(List<Playlist> result)
        {
            _asyncPlaylistsResult = result;
            Completion.Set();
        }

        private void PlaylistsListBuilder(List<List<Playlist>> result)
        {
            _asyncPlaylistsResult = new List<Playlist>();
            foreach (var userResult in result)
            {
                _asyncPlaylistsResult.InsertRange(0, userResult);
            }
            Completion.Set();
        }
    }
}
