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
            public bool Equals(User x, User y)
            {
                return (x.AvatarData == y.AvatarData) && (x.AvatarUrl == y.AvatarUrl.Substring(0, y.AvatarUrl.IndexOf(".jpg", StringComparison.Ordinal) + 4)) &&
                       (x.City == y.City) && (x.Country == y.Country) &&
                       (x.Description == y.Description) && (x.DiscogsName == y.DiscogsName) &&
                       (x.FollowersCount == y.FollowersCount) && (x.FollowingsCount == y.FollowingsCount) &&
                       (x.FullName == y.FullName) && (x.Id == y.Id) &&
                       (x.MyspaceName == y.MyspaceName) && (x.Permalink == y.Permalink) && (x.PermalinkUrl == y.PermalinkUrl) &&
                       (x.Plan == y.Plan) && (x.PlaylistCount == y.PlaylistCount) &&                        
                       (x.PublicFavoritesCount == y.PublicFavoritesCount) &&
                       (x.TrackCount == y.TrackCount) && (x.Uri == y.Uri) &&
                       (x.Username == y.Username) && (x.Website == y.Website) &&
                       (x.WebsiteTitle == y.WebsiteTitle);
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
                                          Username = "Owlandrews",
                                          Uri = "http://api.soundcloud.com/users/509497",
                                          PermalinkUrl = "http://soundcloud.com/owlandrews",
                                          AvatarUrl = "https://i1.sndcdn.com/avatars-000071198254-gx9y0q-large.jpg",
                                          Country = "Britain (UK)",
                                          FullName = "Owl",
                                          Description = "Bristol based producer; releases on Car Crash Set and a resident for Bristol Bass. \r\n\r\nContact owl@wehideinplainsight.net for bookings.",
                                          City = "Bristol",
                                          DiscogsName = null,
                                          Online = true,
                                          TrackCount = 12,
                                          PlaylistCount = 0,
                                          Plan = "Free",
                                          PublicFavoritesCount = 11,
                                          FollowersCount = 139,
                                          FollowingsCount = 102,
            };
            Assert.AreEqual(expectedUser.AvatarUrl, user.AvatarUrl.Substring(0, user.AvatarUrl.IndexOf(".jpg", StringComparison.Ordinal) + 4));
            Assert.AreEqual(expectedUser.City, user.City);
            Assert.AreEqual(expectedUser.Country, user.Country);
            Assert.AreEqual(expectedUser.Description, user.Description);
            Assert.AreEqual(expectedUser.DiscogsName, user.DiscogsName);
            Assert.AreEqual(expectedUser.FollowersCount, user.FollowersCount);
            Assert.AreEqual(expectedUser.FollowingsCount, user.FollowingsCount);
            Assert.AreEqual(expectedUser.FullName, user.FullName);
            Assert.AreEqual(expectedUser.Id, user.Id);
            Assert.AreEqual(expectedUser.MyspaceName, user.MyspaceName);
            //Assert.AreEqual(expectedUser.Online, user.Online);
            Assert.AreEqual(expectedUser.Permalink, user.Permalink);
            Assert.AreEqual(expectedUser.Plan, user.Plan);
            Assert.AreEqual(expectedUser.PlaylistCount, user.PlaylistCount);
            Assert.AreEqual(expectedUser.PublicFavoritesCount, user.PublicFavoritesCount);
            Assert.AreEqual(expectedUser.TrackCount, user.TrackCount);
            Assert.AreEqual(expectedUser.Uri, user.Uri);
            Assert.AreEqual(expectedUser.Username, user.Username);
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
