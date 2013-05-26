using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class SharedToEmails : ResourceBase<List<Models.Email>>, ISharedToEmails
    {
        internal SharedToEmails(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.SharedToEmails;
        }
    }
}
