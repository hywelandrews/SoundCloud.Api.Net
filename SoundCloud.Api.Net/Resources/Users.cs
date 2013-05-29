using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Users : ResourceBase<List<Models.User>, IUsers>, IUsers
    {
        internal Users(RestRequest request, ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Users;
        }

        internal Users(ISoundCloudApiInternal soundCloudApi)
            : base(soundCloudApi)
        {
            Request.Resource = Uri.Users;
        } 
    }
}
