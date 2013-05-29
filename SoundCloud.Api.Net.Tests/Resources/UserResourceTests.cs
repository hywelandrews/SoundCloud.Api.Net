using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Resources.Interfaces;
using SoundCloud.Api.Net.Tests.Configuration;
using User = SoundCloud.Api.Net.Models.User;

namespace SoundCloud.Api.Net.Tests.Resources
{
    [TestFixture]
    public class UserResourceTests
    {
        private ManualResetEvent _completion;
        private User _asyncUserResult;
        private List<User> _asyncUsersResult;
        private ISoundCloudApi _soundCloudApi;
        private ISoundCloudApi _soundCloudApiAuthenticate;
        private PasswordCredentialsState _passwordCredentialsState;

        private class UserComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                return (x.AvatarData == y.AvatarData) && (x.AvatarUrl == y.AvatarUrl) &&
                       (x.City == y.City) && (x.Country == y.Country) &&
                       (x.Description == y.Description) && (x.DiscogsName == y.DiscogsName) &&
                       (x.FollowersCount == y.FollowersCount) && (x.FollowingsCount == y.FollowingsCount) &&
                       (x.FullName == y.FullName) && (x.Id == y.Id) &&
                       (x.Kind == y.Kind) && (x.MyspaceName == y.MyspaceName) &&
                       (x.Online == y.Online) && (x.Permalink == y.Permalink) &&
                       (x.PermalinkUrl == y.PermalinkUrl) && (x.Plan == y.Plan) &&
                       (x.PlaylistCount == y.PlaylistCount) && (x.PublicFavoritesCount == y.PublicFavoritesCount) &&
                       (x.TrackCount == y.TrackCount) && (x.Uri == y.Uri) &&
                       (x.Username == y.Username) && (x.Website == y.Website) &&
                       (x.WebsiteTitle == y.WebsiteTitle);
            }

            public int GetHashCode(User obj)
            {
                throw new NotImplementedException();
            }
        }

        [SetUp]
        public void Initialize()
        {
            ValidateConfiguration();
            _soundCloudApi = SoundCloudApiFactory.GetSoundCloudApi(TestSettings.ClientId, TestSettings.ClientSecret);
            _passwordCredentialsState = new PasswordCredentialsState();
            _soundCloudApiAuthenticate = SoundCloudApiFactory.GetSoundCloudApi(TestSettings.ClientId, TestSettings.ClientSecret, TestSettings.UserName, TestSettings.Password, _passwordCredentialsState);
        }

        private void ValidateConfiguration()
        {
            if (String.IsNullOrEmpty(TestSettings.ClientId))
            {
                throw new Exception("Application setting clientId not configured in: SoundCloud.Api.Net.TestSettings");
            }

            if (String.IsNullOrEmpty(TestSettings.ClientSecret))
            {
                throw new Exception("Application setting clientSecret not configured in: SoundCloud.Api.Net.TestSettings");
            }

            if (String.IsNullOrEmpty(TestSettings.UserName))
            {
                throw new Exception("User setting username not configured in: SoundCloud.Api.Net.TestSettings");
            }

            if (String.IsNullOrEmpty(TestSettings.Password))
            {
                throw new Exception("User setting password not configured in: SoundCloud.Api.Net.TestSettings");
            }
        }
        
        [Test]
        public void TestGetUserRequest()
        {
            var user = _soundCloudApi.User(509497).Get();
            Assert.AreEqual(509497, user.Id);
        }

        [Test]
        public void TestAllPropertiesGetUserRequest()
        {
            var user = _soundCloudApi.User(509497).Get();
            var expectedUser = new User { Id = 509497,
                                          Kind = "user",
                                          Permalink = "owlmusic",
                                          Username = "Owlmusic",
                                          Uri = "http://api.soundcloud.com/users/509497",
                                          PermalinkUrl = "http://soundcloud.com/owlmusic",
                                          AvatarUrl = "http://i1.sndcdn.com/avatars-000016346611-rvk5pn-large.jpg?9d68d37",
                                          Country = "Britain (UK)",
                                          FullName = "Owl",
                                          Description = "Bristol based producer; releases on Car Crash Set and a resident for Bristol Bass. Contact djsparko@gmail.com for bookings.",
                                          City = "Bristol",
                                          DiscogsName = "sparkooo",
                                          Website = "http://grasshopperliesheavy.co.uk",
                                          Online = false,
                                          TrackCount = 12,
                                          PlaylistCount = 0,
                                          Plan = "Free",
                                          PublicFavoritesCount = 5,
                                          FollowersCount = 137,
                                          FollowingsCount = 106,
                                          WebsiteTitle = String.Empty
            };
            Assert.True(new UserComparer().Equals(expectedUser, user));
        }

        [Test]
        public void TestGetUserWithOAuthRequest()
        {
            var user = _soundCloudApiAuthenticate.User().Get();
            Assert.AreEqual(509497, user.Id);
        }

        [Test]
        public void TestGetUserWithOAuthRequestForceRefresh()
        {
            _soundCloudApiAuthenticate.User().Get();

            var token = _passwordCredentialsState.Load();
            token.expires_in = 1;
            // Override the usual hour long session soundcloud sends back

            while (!token.HasExpired())
            {
                Thread.Sleep(100);
            }
            _passwordCredentialsState.Save(token);

            _soundCloudApiAuthenticate = SoundCloudApiFactory.GetSoundCloudApi(TestSettings.ClientId, TestSettings.ClientSecret, _passwordCredentialsState);
            var user = _soundCloudApiAuthenticate.User().Get();
            Assert.IsNotEmpty(user.Username);
        }

        [Test]
        public void TestGetUserAsyncWithOAuth()
        {
            _completion = new ManualResetEvent(false);
            _soundCloudApiAuthenticate.User().GetAsync(UserBuilder);
            _completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.IsNotEmpty(_asyncUserResult.Username);
        }

        [Test]
        public void TestGetMultipleRequests()
        {
            var resourceList = new List<IUser>
                {
                    _soundCloudApi.User(509497),
                    _soundCloudApi.User(509497),
                    _soundCloudApi.User(509497),
                };
            var users = _soundCloudApi.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        [Test]
        public void TestGetMultipleRequestsWithOAuth()
        {
            var resourceList = new List<IUser>
                {
                    _soundCloudApi.User(),
                    _soundCloudApi.User(),
                    _soundCloudApi.User(),
                };
            var users = _soundCloudApiAuthenticate.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        [Test]
        public void TestGetAsyncMultipleRequestsWithOAuth()
        {
            _completion = new ManualResetEvent(false);

            var resourceList = new List<IUser>
                {
                    _soundCloudApi.User(),
                    _soundCloudApi.User(),
                    _soundCloudApi.User(),
                };
            
            _soundCloudApiAuthenticate.ExecuteAsync(resourceList, UserListBuilder);
            Assert.AreEqual(3, _asyncUsersResult.Count);
        }

        private void UserBuilder(User result)
        {
            _asyncUserResult = result;
            _completion.Set();
        }

        private void UserListBuilder(List<User> result)
        {
            _asyncUsersResult = result;
            _completion.Set();
        }
    }
}
