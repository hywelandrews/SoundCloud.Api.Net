using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundCloud.Api.Net.Resources;
using SoundCloud.Api.Net.Tests.Configuration;
using User = SoundCloud.Api.Net.Models.User;

namespace SoundCloud.Api.Net.Tests.Resources
{
    [TestClass]
    public class UserResourceTests
    {
        private ManualResetEvent _completion;
        private User _asyncUserResult;
        private List<User> _asyncUsersResult;
        private ISoundCloudApi _soundCloudApi;
        private ISoundCloudApi _soundCloudApiAuthenticate;
        private PasswordCredentialsState _passwordCredentialsState;

        [TestInitialize]
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
                throw new AssertFailedException("Application setting clientId not configured in: SoundCloud.Api.Net.TestSettings");
            }

            if (String.IsNullOrEmpty(TestSettings.ClientSecret))
            {
                throw new AssertFailedException("Application setting clientSecret not configured in: SoundCloud.Api.Net.TestSettings");
            }

            if (String.IsNullOrEmpty(TestSettings.UserName))
            {
                throw new AssertFailedException("User setting username not configured in: SoundCloud.Api.Net.TestSettings");
            }

            if (String.IsNullOrEmpty(TestSettings.Password))
            {
                throw new AssertFailedException("User setting password not configured in: SoundCloud.Api.Net.TestSettings");
            }
        }
        
        [TestMethod]
        public void TestGetUserRequest()
        {
            var user = new Net.Resources.User(509497).Get(_soundCloudApi);
            var expectedUser = new User { Id = 509497 };
            Assert.AreEqual(expectedUser.Id, user.Id);
        }

        [TestMethod]
        public void TestGetUserFullNameRequest()
        {
            var user = new Net.Resources.User(509497).Get(_soundCloudApi);
            var expectedUser = new User { Id = 509497, FullName = "Owl" };
            Assert.AreEqual(expectedUser.FullName, user.FullName);
        }

        [TestMethod]
        public void TestGetUserWithOAuthRequest()
        {
            var user = new Net.Resources.User().Get(_soundCloudApiAuthenticate);
            var expectedUser = new User { Id = 509497 };
            Assert.AreEqual(expectedUser.Id, user.Id);
        }

        [TestMethod]
        public void TestGetUserWithOAuthRequestForceRefresh()
        {
            new Net.Resources.User().Get(_soundCloudApiAuthenticate);

            var token = _passwordCredentialsState.Load();
            token.expires_in = 1;
            // Override the usual hour long session soundcloud sends back

            while (!token.HasExpired())
            {
                Thread.Sleep(100);
            }
            _passwordCredentialsState.Save(token);

            _soundCloudApiAuthenticate = SoundCloudApiFactory.GetSoundCloudApi(TestSettings.ClientId, TestSettings.ClientSecret, _passwordCredentialsState);
            var user = new Net.Resources.User().Get(_soundCloudApiAuthenticate);
            var expectedUser = new User { Id = 509497 };
            Assert.AreEqual(expectedUser.Id, user.Id);
        }

        [TestMethod]
        public void TestGetUserAsyncWithOAuth()
        {
            _completion = new ManualResetEvent(false);
            new Net.Resources.User().GetAsync(_soundCloudApiAuthenticate, UserBuilder);
            _completion.WaitOne(TimeSpan.FromSeconds(100));
            Assert.AreEqual(509497, _asyncUserResult.Id);
        }

        [TestMethod]
        public void TestGetMultipleRequests()
        {
            var resourceList = new List<ResourceBase<User>>
                {
                    new Net.Resources.User(509497),
                    new Net.Resources.User(509497),
                    new Net.Resources.User(509497)
                };
            var users = _soundCloudApi.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        [TestMethod]
        public void TestGetMultipleRequestsWithOAuth()
        {
            var resourceList = new List<ResourceBase<User>>
                {
                    new Net.Resources.User(),
                    new Net.Resources.User(),
                    new Net.Resources.User()
                };
            var users = _soundCloudApiAuthenticate.Execute(resourceList);
            Assert.AreEqual(3, users.Count);
        }

        [TestMethod]
        public void TestGetAsyncMultipleRequestsWithOAuth()
        {
            _completion = new ManualResetEvent(false);

            var resourceList = new List<ResourceBase<User>>
                {
                    new Net.Resources.User(),
                    new Net.Resources.User(),
                    new Net.Resources.User()
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
