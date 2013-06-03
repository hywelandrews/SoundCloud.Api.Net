using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Filters;
using SoundCloud.Api.Net.Resources.Tracks;

namespace SoundCloud.Api.Net.Tests.Resources
{
    [TestFixture]
    public class TracksResourceTests : ResourceTestsBase
    {
        private List<Track> _asyncTracksResult;

        [Test]
        public void TestGetTracksRequest()
        {
            var tracks = SoundCloudApi.Tracks().Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithSearchRequest()
        {
            var tracks = SoundCloudApi.Tracks().Search("Owl").Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithTagsRequest()
        {
            var tags = new List<string> {"dubstep", "garage"};

            var tracks = SoundCloudApi.Tracks().Tags(tags).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithFilterRequest()
        {
            var tracks = SoundCloudApi.Tracks().Filter(Filters.downloadable).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithLicenseRequest()
        {
            var tracks = SoundCloudApi.Tracks().License("all-rights-reserved").Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithBpmFromRequest()
        {
            var tracks = SoundCloudApi.Tracks().BpmFrom(120).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithBpmToRequest()
        {
            var tracks = SoundCloudApi.Tracks().BpmTo(120).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithDurationFromRequest()
        {
            var tracks = SoundCloudApi.Tracks().DurationFrom(60000).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithDurationToRequest()
        {
            var tracks = SoundCloudApi.Tracks().BpmTo(60000).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithCreatedFromRequest()
        {
            var tracks = SoundCloudApi.Tracks().CreatedFrom(new DateTime(2010, 1, 1)).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithCreatedToRequest()
        {
            var tracks = SoundCloudApi.Tracks().CreatedTo(new DateTime(2013, 5, 1)).Get();
            Assert.Greater(tracks.Count, 0);
        }

        [Test]
        public void TestGetTracksWithIdsRequest()
        {
            var ids = new List<int> { 1379060, 1640576 };

            var tracks = SoundCloudApi.Tracks().Ids(ids).Get();
            Assert.AreEqual(tracks.Count, 2);
        }

        [Test]
        public void TestGetTracksWithAllFiltersRequest()
        {
            var tags = new List<string> { "dubstep", "garage" };

            var tracks = SoundCloudApi.Tracks()
                                      .Tags(tags)
                                      .Search("Owl")
                                      .Filter(Filters.streamable)
                                      .License("all-rights-reserved")
                                      .BpmFrom(100)
                                      .BpmTo(160)
                                      .DurationFrom(10000)
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
            SoundCloudApi.Tracks().GetAsync(TrackListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncTracksResult.Count, 0);
        }

        [Test]
        public void TestGetTracksWithSearchAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApi.Tracks().Search("Owl").GetAsync(TrackListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncTracksResult.Count, 0);
        }

        [Test]
        public void TestGetTracksUsingOAuthRequest()
        {
            SoundCloudApiAuthenticate.Tracks().Get();
            Assert.Greater(_asyncTracksResult.Count, 0);
        }

        [Test]
        public void TestGetTracksWithSearchUsingOAuthRequest()
        {
            SoundCloudApiAuthenticate.Tracks().Search("Owl").Get();
            Assert.Greater(_asyncTracksResult.Count, 0);
        }

        [Test]
        public void TestGetTracksMultipleRequest()
        {
            var requests = new List<ITracks>
                {
                    SoundCloudApi.Tracks(),
                    SoundCloudApi.Tracks(),
                    SoundCloudApi.Tracks(),
                };
            var users = SoundCloudApi.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetTracksWithOAuthMultipleRequest()
        {
            var requests = new List<ITracks>
                {
                    SoundCloudApiAuthenticate.Tracks(),
                    SoundCloudApiAuthenticate.Tracks(),
                    SoundCloudApiAuthenticate.Tracks(),
                };
            var users = SoundCloudApiAuthenticate.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetTracksAsyncMultipleRequest()
        {
            Completion = new ManualResetEvent(false);
            var requests = new List<ITracks>
                {
                    SoundCloudApi.Tracks(),
                    SoundCloudApi.Tracks(),
                    SoundCloudApi.Tracks(),
                };
            SoundCloudApiAuthenticate.ExecuteAsync(requests, TrackListBuilder);
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
