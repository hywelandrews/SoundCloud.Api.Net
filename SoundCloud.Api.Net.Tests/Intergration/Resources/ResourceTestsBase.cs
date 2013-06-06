﻿using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using SoundCloud.Api.Net.Models;
using SoundCloud.Api.Net.Tests.Configuration;

namespace SoundCloud.Api.Net.Tests.Resources
{
    public class ResourceTestsBase
    {
        protected ISoundCloudApi SoundCloudApi;
        protected ISoundCloudApi SoundCloudApiAuthenticate;
        protected PasswordCredentialsState PasswordCredentialsState;
        protected ManualResetEvent Completion;

        [SetUp]
        public void Initialize()
        {
            ValidateConfiguration();
            SoundCloudApi = SoundCloudApiFactory.GetSoundCloudApi(TestSettings.ClientId, TestSettings.ClientSecret);
            PasswordCredentialsState = new PasswordCredentialsState();
            SoundCloudApiAuthenticate = SoundCloudApiFactory.GetSoundCloudApi(TestSettings.ClientId, TestSettings.ClientSecret, TestSettings.UserName, TestSettings.Password, PasswordCredentialsState);
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

        protected class MiniUserComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                return (x.AvatarUrl == y.AvatarUrl) && (x.Id == y.Id) &&
                       (x.PermalinkUrl == y.PermalinkUrl) && (x.Permalink == y.Permalink) &&
                       (x.Uri == y.Uri) && (x.Username == y.Username);
            }

            public int GetHashCode(User obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}