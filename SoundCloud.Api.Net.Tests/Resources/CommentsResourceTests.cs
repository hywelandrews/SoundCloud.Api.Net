using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Comments;

namespace SoundCloud.Api.Net.Tests.Resources
{
    [TestFixture]
    public class CommentsResourceTests : ResourceTestsBase
    {
        private List<Comment> _asyncCommentsResult;

        [Test]
        public void TestGetCommentsRequest()
        {
            var playlists = SoundCloudApi.Comments().Get();
            Assert.Greater(playlists.Count, 0);
        }

        [Test]
        public void TestGetCommentsAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApi.Comments().GetAsync(CommentsListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncCommentsResult.Count, 0);
        }

        [Test]
        public void TestGetCommentsMultipleRequest()
        {
            var requests = new List<IComments>
                {
                    SoundCloudApi.Comments(),
                    SoundCloudApi.Comments(),
                    SoundCloudApi.Comments(),
                };
            var users = SoundCloudApi.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetCommentsWithOAuthMultipleRequest()
        {
            var requests = new List<IComments>
                {
                    SoundCloudApiAuthenticate.Comments(),
                    SoundCloudApiAuthenticate.Comments(),
                    SoundCloudApiAuthenticate.Comments(),
                };
            var users = SoundCloudApiAuthenticate.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetCommentsAsyncMultipleRequest()
        {
            Completion = new ManualResetEvent(false);
            var requests = new List<IComments>
                {
                    SoundCloudApi.Comments(),
                    SoundCloudApi.Comments(),
                    SoundCloudApi.Comments(),
                };
            SoundCloudApiAuthenticate.ExecuteAsync(requests, CommentsListBuilder);
            Assert.Greater(_asyncCommentsResult.Count, 0);
        }

        private void CommentsListBuilder(List<Comment> result)
        {
            _asyncCommentsResult = result;
            Completion.Set();
        }

        private void CommentsListBuilder(List<List<Comment>> result)
        {
            _asyncCommentsResult = new List<Comment>();
            foreach (var userResult in result)
            {
                _asyncCommentsResult.InsertRange(0, userResult);
            }
            Completion.Set();
        }
    }
}
