using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Resources.User;
using SoundCloud.Api.Net.Tests.Intergration.Configuration;

namespace SoundCloud.Api.Net.Tests.Intergration.Resources
{
    [TestFixture]
    public class UserResourceTests : ResourceTestsBase
    {
        private User _asyncUserResult;
        private List<User> _asyncUsersResult;

        private class UserComparer : IEqualityComparer<User>
        {
            public bool Equals(User expected, User actual)
            {
                return (expected.AvatarData == actual.AvatarData) && (expected.AvatarUrl == actual.AvatarUrl.Substring(0, actual.AvatarUrl.IndexOf(".jpg", StringComparison.Ordinal) + 4)) &&
                       (expected.City == actual.City) && (expected.Country == actual.Country) &&
                       (expected.Description == actual.Description) && (expected.DiscogsName == actual.DiscogsName) &&
                       (actual.FollowersCount > expected.FollowersCount) && (actual.FollowingsCount > expected.FollowingsCount) &&
                       (expected.FullName == actual.FullName) && (expected.Id == actual.Id) &&
                       (expected.MyspaceName == actual.MyspaceName) && (expected.Permalink == actual.Permalink) && (expected.PermalinkUrl == actual.PermalinkUrl) &&
                       (expected.Plan == actual.Plan) && (expected.PlaylistCount == actual.PlaylistCount) &&
                       (actual.PublicFavoritesCount > expected.PublicFavoritesCount) &&
                       (actual.TrackCount > expected.TrackCount) && (expected.Uri == actual.Uri) &&
                       (expected.Username == actual.Username) && (expected.Website == actual.Website) &&
                       (expected.WebsiteTitle == actual.WebsiteTitle);
            }

            public int GetHashCode(User obj)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void TestGetUserRequest()
        {
            var user = SoundCloudApiUnAuthenticated.User(509497).Get();
            Assert.AreEqual(509497, user.Id);
        }

        [Test]
        public void TestAllPropertiesGetUserRequest()
        {
            var user = SoundCloudApiUnAuthenticated.User(509497).Get();
            var expectedUser = new User { Id = 509497,
                                          Permalink = "owlandrews",
                                          Username = "Owl Andrews",
                                          Uri = "https://api.soundcloud.com/users/509497",
                                          PermalinkUrl = "https://soundcloud.com/owlandrews",
                                          AvatarUrl = "https://i1.sndcdn.com/avatars-000071198254-gx9y0q-large.jpg",
                                          Country = null,
                                          FullName = "Owl Andrews",
                                          Description = "Bristol based producer; releases on Car Crash Set and a resident for Bristol Bass. \r\n\r\nContact owl@wehideinplainsight.net for bookings.",
                                          City = "Bristol",
                                          DiscogsName = null,
                                          Online = true,
                                          TrackCount = 1,
                                          PlaylistCount = 0,
                                          Plan = "Free",
                                          PublicFavoritesCount = 1,
                                          FollowersCount = 1,
                                          FollowingsCount = 1,
            };
            Assert.AreEqual(expectedUser.AvatarUrl, user.AvatarUrl.Substring(0, user.AvatarUrl.IndexOf(".jpg", StringComparison.Ordinal) + 4));
            Assert.AreEqual(expectedUser.City, user.City);
            Assert.AreEqual(expectedUser.Country, user.Country);
            Assert.AreEqual(expectedUser.Description, user.Description);
            Assert.AreEqual(expectedUser.DiscogsName, user.DiscogsName);
            Assert.GreaterOrEqual(user.FollowersCount, expectedUser.FollowersCount);
            Assert.GreaterOrEqual(user.FollowingsCount, expectedUser.FollowingsCount);
            Assert.AreEqual(user.FullName, expectedUser.FullName);
            Assert.AreEqual(expectedUser.Id, user.Id);
            Assert.AreEqual(expectedUser.MyspaceName, user.MyspaceName);
            //Assert.AreEqual(expectedUser.Online, user.Online);
            Assert.AreEqual(expectedUser.Permalink, user.Permalink);
            Assert.AreEqual(expectedUser.Plan, user.Plan);
            Assert.AreEqual(expectedUser.PlaylistCount, user.PlaylistCount);
            Assert.GreaterOrEqual(user.PublicFavoritesCount, expectedUser.PublicFavoritesCount);
            Assert.GreaterOrEqual(user.TrackCount, expectedUser.TrackCount);
            Assert.AreEqual(expectedUser.Uri, user.Uri);
            Assert.AreEqual(user.Username, expectedUser.Username);
            Assert.AreEqual(expectedUser.Website, user.Website);
            Assert.AreEqual(expectedUser.WebsiteTitle, user.WebsiteTitle);
            Assert.True(new UserComparer().Equals(expectedUser, user));
        }

        [Test]
        public void TestGetUserWithOAuthRequest()
        {
            var user = SoundCloudApiAuthenticated.User().Get();
            Assert.AreEqual(509497, user.Id);
        }

        [Test]
        public void TestGetUserWithOAuthRequestForceRefresh()
        {
            SoundCloudApiAuthenticated.User().Get();

            var token = PasswordCredentialsState.Load();
            token.ExpiresIn = 1;
            // Override the usual hour long session soundcloud sends back

            while (!token.HasExpired())
            {
                Thread.Sleep(100);
            }
            PasswordCredentialsState.Save(token);

            SoundCloudApiAuthenticated = SoundCloudApi.CreateClient(TestSettings.ClientId, TestSettings.ClientSecret, PasswordCredentialsState);
            var user = SoundCloudApiAuthenticated.User().Get();
            Assert.IsNotEmpty(user.Username);
        }

        [Test]
        public void TestGetUserAsyncWithOAuth()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiAuthenticated.User().GetAsync(UserBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.IsNotEmpty(_asyncUserResult.Username);
        }

        [Test]
        public void TestGetUserMultipleRequests()
        {
            var resourceList = new List<IUser>
                {
                    SoundCloudApiUnAuthenticated.User(509497),
                    SoundCloudApiUnAuthenticated.User(509497),
                    SoundCloudApiUnAuthenticated.User(509497),
                };
            var users = SoundCloudApiUnAuthenticated.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        [Test]
        public void TestGetUserMultipleRequestsWithOAuth()
        {
            var resourceList = new List<IUser>
                {
                    SoundCloudApiAuthenticated.User(),
                    SoundCloudApiAuthenticated.User(),
                    SoundCloudApiAuthenticated.User(),
                };
            var users = SoundCloudApiAuthenticated.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        [Test]
        public void TestGetUserAsyncMultipleRequestsWithOAuth()
        {
            Completion = new ManualResetEvent(false);

            var resourceList = new List<IUser>
                {
                    SoundCloudApiAuthenticated.User(),
                    SoundCloudApiAuthenticated.User(),
                    SoundCloudApiAuthenticated.User(),
                };
            
            SoundCloudApiAuthenticated.ExecuteAsync(resourceList, UserListBuilder);
            Assert.AreEqual(3, _asyncUsersResult.Count);
        }

        private void UserBuilder(User result)
        {
            _asyncUserResult = result;
            Completion.Set();
        }

        private void UserListBuilder(List<User> result)
        {
            _asyncUsersResult = result;
            Completion.Set();
        }
    }
}
