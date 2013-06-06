﻿using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Resources.User;
using SoundCloud.Api.Net.Tests.Configuration;
using User = SoundCloud.Api.Net.Models.User;

namespace SoundCloud.Api.Net.Tests.Resources
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
                return (x.AvatarData == y.AvatarData) && (x.AvatarUrl == y.AvatarUrl) &&
                       (x.City == y.City) && (x.Country == y.Country) &&
                       (x.Description == y.Description) && (x.DiscogsName == y.DiscogsName) &&
                       (x.FollowersCount == y.FollowersCount) && (x.FollowingsCount == y.FollowingsCount) &&
                       (x.FullName == y.FullName) && (x.Id == y.Id) &&
                       (x.MyspaceName == y.MyspaceName) && (x.Online == y.Online) &&
                       (x.Permalink == y.Permalink) && (x.PermalinkUrl == y.PermalinkUrl) &&
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
            var user = SoundCloudApi.User(509497).Get();
            Assert.AreEqual(509497, user.Id);
        }

        [Test]
        public void TestAllPropertiesGetUserRequest()
        {
            var user = SoundCloudApi.User(509497).Get();
            var expectedUser = new User { Id = 509497,
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
                                          Online = true,
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
            var user = SoundCloudApiAuthenticate.User().Get();
            Assert.AreEqual(509497, user.Id);
        }

        [Test]
        public void TestGetUserWithOAuthRequestForceRefresh()
        {
            SoundCloudApiAuthenticate.User().Get();

            var token = PasswordCredentialsState.Load();
            token.ExpiresIn = 1;
            // Override the usual hour long session soundcloud sends back

            while (!token.HasExpired())
            {
                Thread.Sleep(100);
            }
            PasswordCredentialsState.Save(token);

            SoundCloudApiAuthenticate = SoundCloudApiFactory.GetSoundCloudApi(TestSettings.ClientId, TestSettings.ClientSecret, PasswordCredentialsState);
            var user = SoundCloudApiAuthenticate.User().Get();
            Assert.IsNotEmpty(user.Username);
        }

        [Test]
        public void TestGetUserAsyncWithOAuth()
        {
            Completion = new ManualResetEvent(false);
            SoundCloudApiAuthenticate.User().GetAsync(UserBuilder);
            Completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.IsNotEmpty(_asyncUserResult.Username);
        }

        [Test]
        public void TestGetUserMultipleRequests()
        {
            var resourceList = new List<IUser>
                {
                    SoundCloudApi.User(509497),
                    SoundCloudApi.User(509497),
                    SoundCloudApi.User(509497),
                };
            var users = SoundCloudApi.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        [Test]
        public void TestGetUserMultipleRequestsWithOAuth()
        {
            var resourceList = new List<IUser>
                {
                    SoundCloudApi.User(),
                    SoundCloudApi.User(),
                    SoundCloudApi.User(),
                };
            var users = SoundCloudApiAuthenticate.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        [Test]
        public void TestGetUserAsyncMultipleRequestsWithOAuth()
        {
            Completion = new ManualResetEvent(false);

            var resourceList = new List<IUser>
                {
                    SoundCloudApi.User(),
                    SoundCloudApi.User(),
                    SoundCloudApi.User(),
                };
            
            SoundCloudApiAuthenticate.ExecuteAsync(resourceList, UserListBuilder);
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