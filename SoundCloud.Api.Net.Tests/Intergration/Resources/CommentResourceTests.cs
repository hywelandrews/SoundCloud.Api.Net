using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Comment;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class CommentResourceTests : ResourceTestsBase
    {
        private Comment _asyncCommentResult;

        [Test]
        public void TestGetCommentRequest()
        {
            var comment = SoundCloudApiUnAuthenticated.Comment(13685794).Get();
            Assert.AreEqual(13685794, comment.Id);
        }

        [Test]
        public void TestGetCommentWithOAuthRequest()
        {
            var comment = SoundCloudApiAuthenticated.Comment(13685794).Get();
            Assert.AreEqual(13685794, comment.Id);
        }

        [Test]
        public void TestGetCommentAsyncWithOAuth()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiAuthenticated.Comment(13685794).GetAsync(CommentBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.IsNotEmpty(_asyncCommentResult.Body);
        }

        [Test]
        public void TestGetCommentMultipleRequests()
        {
            var resourceList = new List<IComment>
                {
                    SoundCloudApiUnAuthenticated.Comment(13685794),
                    SoundCloudApiUnAuthenticated.Comment(13685794),
                    SoundCloudApiUnAuthenticated.Comment(13685794),
                };

            var comments = SoundCloudApiUnAuthenticated.Execute(resourceList);
            Assert.AreEqual(3, comments.Count);
        }

        private void CommentBuilder(Comment result)
        {
            _asyncCommentResult = result;
            Completion.Set();
        }
    }
}
