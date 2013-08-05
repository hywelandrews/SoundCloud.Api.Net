﻿using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Playlist;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class PlaylistResourceTests : ResourceTestsBase
    {
        private Playlist _asyncPlaylistResult;

        [Test]
        public void TestGetPlaylistRequest()
        {
            var playlist = SoundCloudApiUnAuthenticated.Playlist(1).Get();
            Assert.AreEqual(1, playlist.Id);
        }

        [Test]
        public void TestGetPlaylistHasCorrectNumberOfTracksRequest()
        {
            var playlist = SoundCloudApiUnAuthenticated.Playlist(1).Get();
            Assert.AreEqual(playlist.TrackCount, playlist.Tracks.Count);
        }

        [Test]
        public void TestGetPlaylistWithOAuthRequest()
        {
            var playlist = SoundCloudApiAuthenticated.Playlist(1).Get();
            Assert.AreEqual(1, playlist.Id);
        }

        [Test]
        public void TestGetPlaylistAsyncWithOAuth()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiAuthenticated.Playlist(1).GetAsync(PlaylistBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.IsNotEmpty(_asyncPlaylistResult.Title);
        }

        [Test]
        public void TestGetPlaylistMultipleRequests()
        {
            var resourceList = new List<IPlaylist>
                {
                    SoundCloudApiUnAuthenticated.Playlist(1),
                    SoundCloudApiUnAuthenticated.Playlist(1),
                    SoundCloudApiUnAuthenticated.Playlist(1),
                };

            var users = SoundCloudApiUnAuthenticated.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        private void PlaylistBuilder(Playlist result)
        {
            _asyncPlaylistResult = result;
            Completion.Set();
        }
    }
}
