using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Comments : ResourceBase<List<Models.Comment>>, IComments
    {
        internal Comments(RestRequest request)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Comments;
        }
    }
}
