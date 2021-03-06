﻿using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.SharedToEmails
{
    internal class SharedToEmails : ResourceBase<List<Models.Email>, ISharedToEmails>, ISharedToEmails
    {
        internal SharedToEmails(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.SharedToEmails;
        }
    }
}
