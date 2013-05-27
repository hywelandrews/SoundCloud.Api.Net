﻿using System;
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
            var expectedUser = new User { Id = 509497 };
            Assert.AreEqual(expectedUser.Id, user.Id);
        }

        [Test]
        public void TestGetUserFullNameRequest()
        {
            var user = _soundCloudApi.User(509497).Get();
            var expectedUser = new User { Id = 509497, FullName = "Owl" };
            Assert.AreEqual(expectedUser.FullName, user.FullName);
        }

        [Test]
        public void TestGetUserWithOAuthRequest()
        {
            var user = _soundCloudApiAuthenticate.User().Get();
            var expectedUser = new User { Id = 509497 };
            Assert.AreEqual(expectedUser.Id, user.Id);
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
            var expectedUser = new User { Id = 509497 };
            Assert.AreEqual(expectedUser.Id, user.Id);
        }

        [Test]
        public void TestGetUserAsyncWithOAuth()
        {
            _completion = new ManualResetEvent(false);
            _soundCloudApiAuthenticate.User().GetAsync(UserBuilder);
            _completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.AreEqual(509497, _asyncUserResult.Id);
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
            var users = _soundCloudApi.Execute<User>(resourceList);
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
            var users = _soundCloudApiAuthenticate.Execute<User>(resourceList);
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
            
            _soundCloudApiAuthenticate.ExecuteAsync<User>(resourceList, UserListBuilder);
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
