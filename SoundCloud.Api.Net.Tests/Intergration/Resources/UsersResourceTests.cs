using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.Users;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class UsersResourceTests : ResourceTestsBase
    {
        private List<User> _asyncUsersResult;

        [Test]
        public void TestGetUsersRequest()
        {
            var user = SoundCloudApiUnAuthenticated.Users().Get();
            Assert.Greater(user.Count, 0);
        }

        [Test]
        public void TestGetUsersWithSearchRequest()
        {
            var user = SoundCloudApiUnAuthenticated.Users().Search("Owl").Get();
            Assert.Greater(user.Count, 0);
        }

        [Test]
        public void TestGetUsersAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Users().GetAsync(UserListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        [Test]
        public void TestGetUsersWithSearchAsyncRequest()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiUnAuthenticated.Users().Search("Owl").GetAsync(UserListBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        [Test]
        public void TestGetUsersUsingOAuthRequest()
        {
            SoundCloudApiAuthenticated.Users().Get();
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        [Test]
        public void TestGetUsersWithSearchUsingOAuthRequest()
        {
            SoundCloudApiAuthenticated.Users().Search("Owl").Get();
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        [Test]
        public void TestGetUsersMultipleRequest()
        {
            var requests = new List<IUsers>
                {
                    SoundCloudApiUnAuthenticated.Users(),
                    SoundCloudApiUnAuthenticated.Users(),
                    SoundCloudApiUnAuthenticated.Users(),
                };
            var users = SoundCloudApiUnAuthenticated.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetUsersWithOAuthMultipleRequest()
        {
            var requests = new List<IUsers>
                {
                    SoundCloudApiAuthenticated.Users(),
                    SoundCloudApiAuthenticated.Users(),
                    SoundCloudApiAuthenticated.Users(),
                };
            var users = SoundCloudApiAuthenticated.Execute(requests);
            Assert.Greater(users.Count, 0);
        }

        [Test]
        public void TestGetUsersAsyncMultipleRequest()
        {
            Completion = new ManualResetEvent(false);
            var requests = new List<IUsers>
                {
                    SoundCloudApiAuthenticated.Users(),
                    SoundCloudApiAuthenticated.Users(),
                    SoundCloudApiAuthenticated.Users(),
                };
            SoundCloudApiAuthenticated.ExecuteAsync(requests, UserListBuilder);
            Assert.Greater(_asyncUsersResult.Count, 0);
        }

        private void UserListBuilder(List<User> result)
        {
            _asyncUsersResult = result;
            Completion.Set();
        }

        private void UserListBuilder(List<List<User>> result)
        {
            _asyncUsersResult = new List<User>();
            foreach (var userResult in result)
            {
                _asyncUsersResult.InsertRange(0, userResult);   
            }
            Completion.Set();
        }
    }
}
