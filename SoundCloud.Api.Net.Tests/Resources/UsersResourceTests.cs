using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Tests.Resources
{
    [TestFixture]
    public class UsersResourceTests : ResourceTestsBase
    {
        private ManualResetEvent _completion;
        private List<User> _asyncUsersResult;

        [Test]
        public void TestGetUsersRequest()
        {
            var user = SoundCloudApi.Users().Get();
            Assert.Greater(user.Count, 0);
        }

        [Test]
        public void TestGetUsersWithSearchRequest()
        {
            var user = SoundCloudApi.Users().Search("Owl").Get();
            Assert.Greater(user.Count, 0);
        }

        [Test]
        public void TestGetUsersAsyncRequest()
        {
            _completion = new ManualResetEvent(false);
            SoundCloudApi.Users().GetAsync(UserListBuilder);
            _completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        [Test]
        public void TestGetUsersWithSearchAsyncRequest()
        {
            _completion = new ManualResetEvent(false);
            SoundCloudApi.Users().Search("Owl").GetAsync(UserListBuilder);
            _completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        [Test]
        public void TestGetUsersUsingOAuthRequest()
        {
            SoundCloudApiAuthenticate.Users().Get();
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        [Test]
        public void TestGetUsersWithSearchUsingOAuthRequest()
        {
            SoundCloudApiAuthenticate.Users().Search("Owl").Get();
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        [Test]
        public void TestGetUsersMultipleRequest()
        {
            var requests = new List<IUsers>
                {
                    SoundCloudApi.Users(),
                    SoundCloudApi.Users(),
                    SoundCloudApi.Users(),
                };
            var users = SoundCloudApiAuthenticate.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetUsersWithOAuthMultipleRequest()
        {
            var requests = new List<IUsers>
                {
                    SoundCloudApiAuthenticate.Users(),
                    SoundCloudApiAuthenticate.Users(),
                    SoundCloudApiAuthenticate.Users(),
                };
            var users = SoundCloudApiAuthenticate.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetUsersAsyncMultipleRequest()
        {
            _completion = new ManualResetEvent(false);
            var requests = new List<IUsers>
                {
                    SoundCloudApi.Users(),
                    SoundCloudApi.Users(),
                    SoundCloudApi.Users(),
                };
            SoundCloudApiAuthenticate.ExecuteAsync(requests, UserListBuilder);
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        private void UserListBuilder(List<User> result)
        {
            _asyncUsersResult = result;
            _completion.Set();
        }

        private void UserListBuilder(List<List<User>> result)
        {
            _asyncUsersResult = new List<User>();
            foreach (var userResult in result)
            {
                _asyncUsersResult.InsertRange(0, userResult);   
            }
            _completion.Set();
        }
    }
}
