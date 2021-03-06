﻿using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Filters;
using SoundCloud.Api.Net.Resources.Tracks;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class TracksResourceTests : ResourceTestsBase
    {
        private List<Track> _asyncTracksResult;

        [Test]
        public void TestGetTracksRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithSearchRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().Search("Owl").Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithTagsRequest()
        {
            var tags = new List<string> { "dubstep", "garage" };

            var tracks = SoundCloudApiUnAuthenticated.Tracks().Tags(tags).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithFilterRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().Filter(Filter.downloadable).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithLicenseRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().License(LicenseFilter.ToShare).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithBpmFromRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().BpmFrom(120).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithBpmToRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().BpmTo(120).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithDurationFromRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().DurationFrom(60000).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithDurationToRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().BpmTo(60000).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithCreatedFromRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().CreatedFrom(new DateTime(2010, 1, 1)).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithCreatedToRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().CreatedTo(new DateTime(2013, 5, 1)).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithIdsRequest()
        {
            var ids = new List<int> { 112385582, 8919569 };

            var tracks = SoundCloudApiUnAuthenticated.Tracks().Ids(ids).Get();
            Assert.AreEqual(2, tracks.Count);
        }

        [Test]
        public void TestGetTracksWithGenresRequest()
        {
            var tracks = SoundCloudApiUnAuthenticated.Tracks().Genres("dubstep").Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithTrackTypesRequest()
        {
            var trackTypes = new List<TypeFilter> { TypeFilter.Demo, TypeFilter.InProgress };

            var tracks = SoundCloudApiUnAuthenticated.Tracks().Types(trackTypes).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithAllFiltersRequest()
        {
            var tags = new List<string> { "dubstep", "garage", "house" };

            var tracks = SoundCloudApiUnAuthenticated.Tracks()
                                      .Tags(tags)
                                      .Search("Owl")
                                      .Filter(Filter.streamable)
                                      .License(LicenseFilter.ToShare)
                                      .BpmFrom(60)
                                      .BpmTo(160)
                                      .DurationFrom(1000)
                                      .DurationTo(120000)
                                      .CreatedFrom(new DateTime(2010, 1, 1))
                                      .CreatedTo(new DateTime(2013, 5, 1))
                                      .Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Tracks().GetAsync(TrackListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncTracksResult.Count, 0);
        }

        [Test]
        public void TestGetTracksWithSearchAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Tracks().Search("Owl").GetAsync(TrackListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncTracksResult.Count, 0);
        }

        [Test]
        public void TestGetTracksUsingOAuthRequest()
        {
            var tracks = SoundCloudApiAuthenticated.Tracks().Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithSearchUsingOAuthRequest()
        {
            var tracks = SoundCloudApiAuthenticated.Tracks().Search("Owl").Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksMultipleRequest()
        {
            var requests = new List<ITracks>
                {
                    SoundCloudApiUnAuthenticated.Tracks(),
                    SoundCloudApiUnAuthenticated.Tracks(),
                    SoundCloudApiUnAuthenticated.Tracks(),
                };
            var users = SoundCloudApiUnAuthenticated.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetTracksWithOAuthMultipleRequest()
        {
            var requests = new List<ITracks>
                {
                    SoundCloudApiAuthenticated.Tracks(),
                    SoundCloudApiAuthenticated.Tracks(),
                    SoundCloudApiAuthenticated.Tracks(),
                };
            var users = SoundCloudApiAuthenticated.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetTracksAsyncMultipleRequest()
        {
            Completion = new ManualResetEvent(false);
            var requests = new List<ITracks>
                {
                    SoundCloudApiAuthenticated.Tracks(),
                    SoundCloudApiAuthenticated.Tracks(),
                    SoundCloudApiAuthenticated.Tracks(),
                };
            SoundCloudApiAuthenticated.ExecuteAsync(requests, TrackListBuilder);
            Assert.Greater(_asyncTracksResult.Count, 0);
        }

        private void TrackListBuilder(List<Track> result)
        {
            _asyncTracksResult = result;
            Completion.Set();
        }

        private void TrackListBuilder(IEnumerable<List<Track>> result)
        {
            _asyncTracksResult = new List<Track>();
            foreach (var userResult in result)
            {
                _asyncTracksResult.InsertRange(0, userResult);
            }
            Completion.Set();
        }
    }
}
