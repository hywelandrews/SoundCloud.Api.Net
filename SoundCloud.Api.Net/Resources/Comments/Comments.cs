using System.Collections.Generic;
using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Comments
{
    internal class Comments : ResourceBase<List<Models.Comment>, IComments>, IComments
    {
        internal Comments(RestRequest request, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + Uri.Comments;
        }
    }
}
