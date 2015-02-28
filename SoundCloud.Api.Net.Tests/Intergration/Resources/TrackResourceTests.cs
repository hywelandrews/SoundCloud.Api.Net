using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class TrackResourceTests : ResourceTestsBase
    {
        private Track _asyncTrackResult;
        private const int TrackId = 112385582;

        private class TrackComparer : IEqualityComparer<Track>
        {
            public bool Equals(Track x, Track y)
            {
                return (x.ArtworkUrl == y.ArtworkUrl.Substring(0, y.ArtworkUrl.IndexOf(".jpg", StringComparison.Ordinal) + 4)) && 
                       (x.Bpm == y.Bpm) && (x.CommentCount == y.CommentCount) && (x.Commentable == y.Commentable) &&
                       (x.CreatedAt == y.CreatedAt) && (x.CreatedWith == y.CreatedWith) &&
                       (x.Description == y.Description) && (x.DownloadCount == y.DownloadCount) &&
                       (x.DownloadUrl == y.DownloadUrl) && (x.Downloadable == y.Downloadable) &&
                       (x.Duration == y.Duration) && (x.EmbeddableBy == y.EmbeddableBy) &&
                       (x.FavoritingsCount == y.FavoritingsCount) && (x.Genre == y.Genre) &&
                       (x.Id == y.Id) && (x.Isrc == y.Isrc) &&
                       (x.KeySignature == y.KeySignature) && (new MiniUserComparer().Equals(x.Label, y.Label)) &&
                       (x.LabelId == y.LabelId) && (x.LabelName == y.LabelName) &&
                       (x.License == y.License) && (x.OriginalContentSize == y.OriginalContentSize) &&
                       (x.OriginalFormat == y.OriginalFormat) && (x.Permalink == y.Permalink) &&
                       (x.PermalinkUrl == y.PermalinkUrl) && (x.PlaybackCount == y.PlaybackCount) &&
                       (x.PurchaseUrl == y.PurchaseUrl) && (x.Release == y.Release) &&
                       (x.ReleaseDay == y.ReleaseDay) && (x.ReleaseMonth == y.ReleaseMonth) &&
                       (x.ReleaseYear == y.ReleaseYear) && (x.SharedToCount == y.SharedToCount) &&
                       (x.Sharing == y.Sharing) && (x.State == y.State) &&
                       (x.StreamUrl == y.StreamUrl) && (x.Streamable == y.Streamable) &&
                       (x.TagList == y.TagList) && (x.Title == y.Title) &&
                       (x.TrackType == y.TrackType) && (x.Uri == y.Uri) &&
                       (new MiniUserComparer().Equals(x.User, y.User)) && (x.UserFavorite == y.UserFavorite) &&
                       (x.UserId == y.UserId) && (x.VideoUrl == y.VideoUrl) &&
                       (x.WaveformUrl == y.WaveformUrl);
            }

            public int GetHashCode(Track obj)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void TestGetTrackRequest()
        {
            var track = SoundCloudApiUnAuthenticated.Track(TrackId).Get();
            Assert.AreEqual(TrackId, track.Id);
        }

        [Test]
        public void TestGetTrackAllPropertiesRequest()
        {
            var track = SoundCloudApiUnAuthenticated.Track(TrackId).Get();
            var expectedTrack = new Track
                {
                    Id = TrackId,
                    CreatedAt = new DateTime(2010, 01, 17, 15, 21, 17),
                    UserId = 509497,
                    Duration = 284158,
                    Commentable = true,
                    State = "finished",
                    OriginalContentSize = 50132660,
                    Sharing = "public",
                    TagList = String.Empty,
                    Permalink = "lost-in-kakariko",
                    Streamable = true,
                    EmbeddableBy = "all",
                    Downloadable = false,
                    PurchaseUrl = "http://www.junodownload.com/products/1554271-02.htm",
                    LabelId = 4804,
                    Genre = "Future Garage",
                    Title = "Lost in Kakariko",
                    Description = "Car Crash Set (C/C/S2009)",
                    TrackType = "original",
                    Bpm = 141.0f,
                    Isrc = String.Empty,
                    KeySignature = String.Empty,
                    LabelName = String.Empty,
                    Release = String.Empty,
                    OriginalFormat = "wav",
                    License = "all-rights-reserved",
                    Uri = "http://api.soundcloud.com/tracks/1379060",
                    User = new User
                        {
                            Id = 509497,
                            Permalink = "owlandrews",
                            Username = "Owlandrews",
                            Uri = "http://api.soundcloud.com/users/509497",
                            PermalinkUrl = "http://soundcloud.com/owlandrews",
                            AvatarUrl = "http://i1.sndcdn.com/avatars-000016346611-rvk5pn-large.jpg"
                        },
                    Label = new User
                        {
                            Id = 4804,
                            Permalink = "carcrashset",
                            Username = "Car Crash Set",
                            Uri = "http://api.soundcloud.com/users/4804",
                            PermalinkUrl = "http://soundcloud.com/carcrashset",
                            AvatarUrl = "http://i1.sndcdn.com/avatars-000000176052-e69d19-large.jpg"
                        },
                    PermalinkUrl = "http://soundcloud.com/owlmusic/lost-in-kakariko",
                    ArtworkUrl = "http://i1.sndcdn.com/artworks-000001070867-60u1mw-large.jpg",
                    WaveformUrl = "http://w1.sndcdn.com/0PhxMYJBKnps_m.png",
                    StreamUrl = "http://api.soundcloud.com/tracks/1379060/stream",
                    PlaybackCount = 1,
                    DownloadCount = 0,
                    FavoritingsCount = 1,
                    CommentCount = 1,
                    AttachmentsUri = "http://api.soundcloud.com/tracks/1379060/attachments"
                };
            Assert.Greater(expectedTrack.PlaybackCount, track.PlaybackCount);
            Assert.Greater(expectedTrack.FavoritingsCount, track.FavoritingsCount);
            Assert.Greater(expectedTrack.CommentCount, track.CommentCount);
            Assert.True(new TrackComparer().Equals(expectedTrack, track));
        }

        [Test]
        public void TestGetTrackUsingOAuthRequest()
        {
            var track = SoundCloudApiAuthenticated.Track(TrackId).Get();
            Assert.AreEqual(TrackId, track.Id);
        }

        [Test]
        public void TestGetTrackAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Track(TrackId).GetAsync(TrackBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.AreEqual(TrackId, _asyncTrackResult.Id);
        }

        [Test]
        public void TestGetTrackAsyncUsingOAuthRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiAuthenticated.Track(TrackId).GetAsync(TrackBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.AreEqual(TrackId, _asyncTrackResult.Id);
        }

        [Test]
        public void TestPutTrackUpdateDescription()
        {
            var t = SoundCloudApiAuthenticated.Track(TrackId).Get();
            t.Description = "Here is a new description";
            SoundCloudApiAuthenticated.Track(TrackId).Put(t);
            var x = SoundCloudApiAuthenticated.Track(TrackId).Get();
            Assert.AreEqual("Here is a new description", x.Description);
            SoundCloudApiAuthenticated.Track(TrackId).Put(new Track { Description = String.Empty });
        }

        private void TrackBuilder(Track result)
        {
            _asyncTrackResult = result;
            Completion.Set();
        }
    }
}
